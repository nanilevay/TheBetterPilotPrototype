unsigned long elapsedTime = 0, lastSend = 0, sendTime = 0;

#include <Encoder.h>

Encoder myEnc(6, 7);

void setup()
{
  Serial.begin(115200);

  //Enviar sensor data a 30 FPS
  sendTime = floor(1000 / 30);
}

void loop()
{  
  elapsedTime = millis() - lastSend;
  
  if(elapsedTime > sendTime)
  {
    lastSend = millis();
    
    Serial.print(digitalRead(8));
    Serial.print(" ");
    Serial.println(digitalRead(6));

    
  }
  delay(20);
}
