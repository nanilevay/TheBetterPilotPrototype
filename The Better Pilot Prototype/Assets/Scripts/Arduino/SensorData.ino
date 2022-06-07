unsigned long elapsedTime = 0, lastSend = 0, sendTime = 0;

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
    
    Serial.print(analogRead(A1));
    Serial.print(" ");
    Serial.println(analogRead(A3));
  }
  delay(20);
}
