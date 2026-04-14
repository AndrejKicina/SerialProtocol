<h1>📘 SerialProtocol – Simple Binary Communication Protocol (C# ↔ Arduino/ESP32)</h1>
SerialProtocol is a lightweight, reliable, and fully symmetric communication protocol designed for serial communication between:

a PC application written in C#, and

a microcontroller (Arduino, ESP32, ESP8266, AVR, STM32, …)

The protocol uses a compact binary frame format:

Code
STX | LEN | CMD | PAYLOAD... | CRC
It is built to be:

simple to implement

robust against noise and partial frames

fast and resource‑efficient

identical on both PC and hardware

suitable for request–response communication

<h1>📦 Frame Format</h1>
Field	Description
STX	Start byte (0xAA)
LEN	Length of: CMD + PAYLOAD + CRC
CMD	Command identifier
PAYLOAD	Optional data bytes
CRC	XOR of all previous bytes (excluding CRC)

Example frame:

Code
AA 05 10 01 02 03 B5
<h1>🚀 Features</h1>
SendMessage / SendCommand – send commands with optional payload

ProcessData – byte‑by‑byte state machine for receiving frames

Timeout protection – resets frame reception if bytes arrive too slowly

CRC validation

MessageReceived event/callback on complete valid frame

<h1>🖥️ Usage in C# (PC Side)</h1>
Initialize the protocol
csharp
var proto = new SerialProtocol();
proto.MessageReceived += (cmd, payload) =>
{
    Console.WriteLine($"Received CMD={cmd}, payload={BitConverter.ToString(payload)}");
};

string err;
proto.Start("COM5", out err);
Send a command
csharp
string err;
proto.SendCommand(0x10, new byte[] { 1, 2, 3 }, out err);
Receiving data
Receiving is automatic via SerialPort.DataReceived.
The internal state machine reconstructs frames and fires:

csharp
MessageReceived(cmd, payload)
<h1>🔌 Usage on Arduino / ESP32 (Hardware Side)</h1>
Initialize the protocol
cpp
#include "SerialProtocol.h"

class MyProto : public SerialProtocol {
public:
    MyProto(Stream& s) : SerialProtocol(s) {}

    void MessageReceived(uint8_t cmd, const uint8_t* payload, uint8_t len) override {
        Serial.print("CMD: ");
        Serial.println(cmd);

        Serial.print("Payload length: ");
        Serial.println(len);
    }
};

MyProto proto(Serial);

void setup() {
    Serial.begin(115200);
}
Receive data
cpp
void loop() {
    while (Serial.available()) {
        proto.ProcessData(Serial.read());
    }
}
Send a command
cpp
uint8_t data[] = { 1, 2, 3 };
proto.SendMessage(0x10, data, sizeof(data));
<h1>🔧 Implementation Details</h1>
State machine:
WAIT4STX → WAIT4LEN → WAIT4END

Timeout:
If the gap between bytes exceeds 50 ms, the frame is discarded.

CRC:
XOR of all bytes except CRC.

Max frame length:
255 bytes (fits in a single LEN byte).


<h1>📜 License</h1>
This project is released under the MIT License.
You are free to use, modify, and integrate it into your own applications.

<h1>⭐ Support</h1>
If you find this project useful, consider giving it a ⭐ on GitHub.
