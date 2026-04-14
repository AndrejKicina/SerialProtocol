<h1>📘 SerialProtocol – Simple Binary Communication Protocol (C# ↔ Arduino/ESP32)</h1>
SerialProtocol is a lightweight, reliable, and fully symmetric communication protocol designed for serial communication between a PC application written in C#, and a microcontroller (Arduino, ESP32, ESP8266, AVR, STM32, …)
The protocol uses a compact binary frame format:
STX | LEN | CMD | PAYLOAD... | CRC

It is built to be:
- simple to implement
- robust against noise and partial frames
- fast and resource‑efficient
- identical on both PC and hardware
- suitable for request–response communication

<h1>📦 Frame Format</h1>
    - STX      Start byte (0xAA)
    - LEN      Length of: CMD + PAYLOAD + CRC
    - CMD      Command identifier
    - PAYLOAD  Optional data byte
    - CRC      XOR of all previous bytes (excluding CRC)

Example frame:
AA 05 10 01 02 03 B5

<h1>🚀 Features</h1>
- SendMessage / SendCommand – send commands with optional payload
- ProcessData – byte‑by‑byte state machine for receiving frames
- Timeout protection – resets frame reception if bytes arrive too slowly
- CRC validation
- MessageReceived event/callback on complete valid frame

<h1>🖥️ Usage in C# (PC Side)</h1>
Please see VisualStudio project in the UI folder for example usage.

<h1>🔌 Usage on Arduino / ESP32 (Hardware Side)</h1>
Please see HW/HW.ino file for example usage.

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
