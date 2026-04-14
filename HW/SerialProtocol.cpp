#include "SerialProtocol.h"

SerialProtocol::SerialProtocol(Stream& stream)
    : serial(stream), state(WAIT4STX), expectedLen(0), bufferPos(0), lastByteTime(0)
{
}

void SerialProtocol::reset()
{
    state = WAIT4STX;
    expectedLen = 0;
    bufferPos = 0;
}

bool SerialProtocol::SendMessage(uint8_t cmd, const uint8_t* payload, uint8_t len)
{
    uint8_t totalLen = 1 + len + 1; // CMD + payload + CRC

    uint8_t crc = STX_BYTE ^ totalLen ^ cmd;
    for (uint8_t i = 0; i < len; i++)
        crc ^= payload[i];

    serial.write(STX_BYTE);
    serial.write(totalLen);
    serial.write(cmd);

    for (uint8_t i = 0; i < len; i++)
        serial.write(payload[i]);

    serial.write(crc);

    return true;
}

void SerialProtocol::ProcessData(uint8_t data)
{
    uint32_t now = millis();

    // Timeout
    if (now - lastByteTime > SERIAL_TIMEOUT_MS) {
        reset();
    }
    lastByteTime = now;

    switch (state)
    {
        case WAIT4STX:
            if (data == STX_BYTE) {
                state = WAIT4LEN;
            }
            break;

        case WAIT4LEN:
            expectedLen = data;
            bufferPos = 0;

            if (expectedLen == 0 || expectedLen > MAX_FRAME_SIZE) {
                reset();
                break;
            }

            state = WAIT4END;
            break;

        case WAIT4END:
            buffer[bufferPos++] = data;

            if (bufferPos >= expectedLen)
            {
                uint8_t crc = STX_BYTE ^ expectedLen;

                for (uint8_t i = 0; i < expectedLen - 1; i++)
                    crc ^= buffer[i];

                uint8_t receivedCrc = buffer[expectedLen - 1];

                if (crc == receivedCrc)
                {
                    uint8_t cmd = buffer[0];
                    uint8_t payloadLen = expectedLen - 2;

                    MessageReceived(cmd,
                                    payloadLen > 0 ? &buffer[1] : 0,
                                    payloadLen);
                }

                reset();
            }
            break;
    }
}
