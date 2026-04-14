#ifndef SERIAL_PROTOCOL_H
#define SERIAL_PROTOCOL_H

#include <Arduino.h>

#define STX_BYTE            0xAA
#define SERIAL_TIMEOUT_MS   50
#define MAX_FRAME_SIZE      256

class SerialProtocol
{
public:
    SerialProtocol(Stream& stream);

    bool SendMessage(uint8_t cmd, const uint8_t* payload, uint8_t len);
    void ProcessData(uint8_t data);

    virtual void MessageReceived(uint8_t cmd, const uint8_t* payload, uint8_t len) = 0;

private:
    enum RxState {
        WAIT4STX,
        WAIT4LEN,
        WAIT4END
    };

    Stream& serial;
    RxState state;

    uint8_t expectedLen;
    uint8_t buffer[MAX_FRAME_SIZE];
    uint8_t bufferPos;

    uint32_t lastByteTime;

    void reset();
};

#endif
