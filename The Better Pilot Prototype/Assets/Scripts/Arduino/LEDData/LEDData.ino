#include <FastLED.h>
#include <Servo.h>
#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

#define LED_PIN     6
#define NUM_LEDS    10
#define BRIGHTNESS  200

LiquidCrystal_I2C lcd(0x27, 16, 2);

// Servo Stuff

Servo myservo;  // create servo object to control a servo

CRGB leds[NUM_LEDS];

char bufferLCD[16*2];
byte bufferLED[NUM_LEDS*3];

byte servo;

void setup()
{
   myservo.attach(9);
   
  delay(3000); // sanity delay
  
  Serial.begin(115200);
      
  FastLED.addLeds<WS2812B, LED_PIN, GRB>(leds, NUM_LEDS).setCorrection( TypicalLEDStrip );
  FastLED.setBrightness( BRIGHTNESS );
  FastLED.clear();
  FastLED.show();


  // lcd scripts
  lcd.init();

  lcd.backlight();
  lcd.clear();
  lcd.setCursor(4,0);
  //lcd.print("ha");
  lcd.clear();
  
}

// https://www.arduino.cc/reference/en/language/functions/communication/serial/

void loop()
{  

  while (Serial.available() > 0)
  {
    //Para ser 1 byte (que vai controlar o servo)
    //byte servo = Serial.read();   
    servo = Serial.read();       
    myservo.write(servo);  

    //Para ler 32 bytes (16x2) para o LCD
    //lcd.clear();
    
    Serial.readBytes(bufferLCD, 32);

    if(bufferLCD[0] != 'G' && bufferLCD[1] != 'G')
    {
      // display first code
      lcd.setCursor(0,0);
      lcd.print(bufferLCD[0]);
      lcd.setCursor(1,0);
      lcd.print(bufferLCD[1]);
      lcd.setCursor(2,0);
      lcd.print(bufferLCD[2]);
      lcd.setCursor(3,0);
      lcd.print(bufferLCD[3]);

      // display second code
      lcd.setCursor(5,0);
      lcd.print(bufferLCD[4]);
      lcd.setCursor(6,0);
      lcd.print(bufferLCD[5]);
      lcd.setCursor(7,0);
      lcd.print(bufferLCD[6]);
      lcd.setCursor(8,0);
      lcd.print(bufferLCD[7]);
  
      // display third code
      lcd.setCursor(0,1);
      lcd.print(bufferLCD[8]);
      lcd.setCursor(1,1);
      lcd.print(bufferLCD[9]);
      lcd.setCursor(2,1);
      lcd.print(bufferLCD[10]);
      lcd.setCursor(3,1);
      lcd.print(bufferLCD[11]);

    
      // display fourth code
      lcd.setCursor(5,1);
      lcd.print(bufferLCD[12]);
      lcd.setCursor(6,1);
      lcd.print(bufferLCD[13]);
      lcd.setCursor(7,1);
      lcd.print(bufferLCD[14]);
      lcd.setCursor(8,1);
      lcd.print(bufferLCD[15]);
  
      // display too many codes code
      lcd.setCursor(10,0);
      lcd.print(bufferLCD[16]);
      lcd.setCursor(11,0);
      lcd.print(bufferLCD[17]);
      lcd.setCursor(12,0);
      lcd.print(bufferLCD[18]);
      lcd.setCursor(13,0);
      lcd.print(bufferLCD[19]);

      // display srl num
      lcd.setCursor(10,1);
      lcd.print(bufferLCD[20]);
      lcd.setCursor(11,1);
      lcd.print(bufferLCD[21]);
      lcd.setCursor(12,1);
      lcd.print(bufferLCD[22]);
      lcd.setCursor(13,1);
      lcd.print(bufferLCD[23]);
      lcd.setCursor(14,1);
      lcd.print(bufferLCD[24]);
      lcd.setCursor(15,1);
      lcd.print(bufferLCD[25]);

    }

    else
    {

      // Game Over
      lcd.clear();
      lcd.setCursor(2,0);
      lcd.print(bufferLCD[0]);
      lcd.setCursor(3,0);
      lcd.print(bufferLCD[1]);
      lcd.setCursor(4,0);
      lcd.print(bufferLCD[2]);
      lcd.setCursor(5,0);
      lcd.print(bufferLCD[3]);

      lcd.setCursor(2,1);
      lcd.print(bufferLCD[4]);
      lcd.setCursor(3,1);
      lcd.print(bufferLCD[5]);
      lcd.setCursor(4,1);
      lcd.print(bufferLCD[6]);
      lcd.setCursor(5,1);
      lcd.print(bufferLCD[7]);

      // stopwatch
      lcd.setCursor(7,0);
      lcd.print(bufferLCD[8]);
      lcd.setCursor(8,0);
      lcd.print(bufferLCD[9]);
      lcd.setCursor(9,0);
      lcd.print(bufferLCD[10]);
      lcd.setCursor(10,0);
      lcd.print(bufferLCD[11]);   
      lcd.setCursor(11,0);
      lcd.print(bufferLCD[12]);  
      lcd.setCursor(12,0);
      lcd.print(bufferLCD[13]);   
    }
    
    //Para ler 3 bytes por LED
    Serial.readBytes(bufferLED, NUM_LEDS*3);

    //Para percorrer lista de LEDs e atribuir a cada a cor que recebemos do Unity
    for(int i = 0; i < NUM_LEDS; i++)
    {
      int index = i * 3;
      byte r = bufferLED[index+0]; // :)
      byte g = bufferLED[index+1];
      byte b = bufferLED[index+2];
      
      CRGB color = CRGB(r, g, b);
      leds[i] = color;
    }

    //Para de facto enviar cores para os LEDs
    FastLED.show();
  }

  //delay(20);
}
