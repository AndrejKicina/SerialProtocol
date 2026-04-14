using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace SerialCom
{
    public class SerialProtocol
    {
        private const int SERIAL_SPEED = 9600;
        private const int SERIAL_TIMEOUT_MS = 50;

        private SerialPort? _serialPort = null;

        private enum SpecialCharacters : byte
        {
            STX = 0xAA,   // start of transmission
            ACK = 0x10,   // acknowledge (rezerva)
            NACK = 0x13,  // not acknowledge (rezerva)
        }

        private enum RxState
        {
            WAIT4STX,
            WAIT4LEN,
            WAIT4END
        }

        private RxState _state = RxState.WAIT4STX;

        private byte _expectedLen = 0;
        private readonly byte[] _buffer = new byte[256];
        private int _bufferPos = 0;

        private DateTime _lastByteTime = DateTime.MinValue;

        public delegate void MessageReceivedHandler(byte cmd, byte[] payload);
        public event MessageReceivedHandler? MessageReceived;

        public bool Start(string comPort, out string err)
        {
            err = string.Empty;

            try
            {
                Stop(); // make sure serial port is closed before opening new one

                _serialPort = new SerialPort(comPort, SERIAL_SPEED);
                _serialPort.DataReceived += SerialPort_DataReceived;
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return string.IsNullOrEmpty(err);
        }

        public void Stop()
        {
            if (_serialPort != null)
            {
                _serialPort.DataReceived -= SerialPort_DataReceived;

                if (_serialPort.IsOpen)
                    _serialPort.Close();
            }
        }

        /// <summary>
        /// Send specified command to COM port
        /// </summary>
        public bool SendCommand(byte command, byte[]? data, out string err)
        {
            err = string.Empty;

            try
            {
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    err = "serial port is not opened";
                    return false;
                }

                var buffer = new List<byte>();
                int len = 1 + (data?.Length ?? 0) + 1;  // CMD + payload + CRC

                if (len > 255)
                {
                    err = $"Message too long for sending ({len}), max is 255";
                    return false;
                }

                buffer.Add((byte)SpecialCharacters.STX); // STX
                buffer.Add((byte)len);                   // LEN
                buffer.Add(command);                     // CMD

                if (data != null && data.Length > 0)
                    buffer.AddRange(data);               // PAYLOAD

                byte crc = 0;
                foreach (var b in buffer)
                    crc ^= b;

                buffer.Add(crc);                         // CRC

                _serialPort.Write(buffer.ToArray(), 0, buffer.Count);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return string.IsNullOrWhiteSpace(err);
        }

        private void SerialPort_DataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort == null)
                return;

            try
            {
                while (_serialPort.BytesToRead > 0)
                {
                    int val = _serialPort.ReadByte();
                    if (val < 0)
                        break;

                    ProcessData((byte)val);
                }
            }
            catch
            {
                ResetReceiver();
            }
        }

        private void ProcessData(byte data)
        {
            // Timeout ochrana
            if ((DateTime.Now - _lastByteTime).TotalMilliseconds > SERIAL_TIMEOUT_MS)
            {
                //ResetReceiver();
            }
            _lastByteTime = DateTime.Now;

            switch (_state)
            {
                case RxState.WAIT4STX:
                    if (data == (byte)SpecialCharacters.STX)
                    {
                        _state = RxState.WAIT4LEN;
                    }
                    break;

                case RxState.WAIT4LEN:
                    _expectedLen = data;
                    _bufferPos = 0;

                    if (_expectedLen == 0 || _expectedLen > 255)
                    {
                        ResetReceiver();
                        break;
                    }

                    _state = RxState.WAIT4END;
                    break;

                case RxState.WAIT4END:
                    _buffer[_bufferPos++] = data;

                    if (_bufferPos >= _expectedLen)
                    {
                        byte crc = (byte)((byte)SpecialCharacters.STX ^ _expectedLen);

                        for (int i = 0; i < _expectedLen - 1; i++)
                            crc ^= _buffer[i];

                        byte receivedCrc = _buffer[_expectedLen - 1];

                        if (crc == receivedCrc)
                        {
                            byte cmd = _buffer[0];
                            int payloadLen = _expectedLen - 2;

                            byte[] payload = new byte[payloadLen];
                            if (payloadLen > 0)
                                Array.Copy(_buffer, 1, payload, 0, payloadLen);

                            MessageReceived?.Invoke(cmd, payload);
                        }

                        ResetReceiver();
                    }
                    break;
            }
        }

        private void ResetReceiver()
        {
            _state = RxState.WAIT4STX;
            _expectedLen = 0;
            _bufferPos = 0;
        }
    }
}
