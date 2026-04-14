#include "SerialProtocol.h"

class MyProto : public SerialProtocol {
public:
    MyProto(Stream& s) : SerialProtocol(s) {}

    void MessageReceived(uint8_t cmd, const uint8_t* payload, uint8_t len) override {
      digitalWrite(LED_BUILTIN, !digitalRead(LED_BUILTIN));

      // return message
      SendMessage(cmd, payload, len);
    }
};

MyProto proto(Serial);

void setup() {
    Serial.begin(9600);
    pinMode(LED_BUILTIN, OUTPUT);
    digitalWrite(LED_BUILTIN, LOW);
}

void loop() {
    while (Serial.available()) {
        proto.ProcessData(Serial.read());
    }
}
