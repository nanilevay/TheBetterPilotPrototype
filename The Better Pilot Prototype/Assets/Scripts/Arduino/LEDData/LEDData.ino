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


void DisplayUpdater(int startingPos, int startingIndex, int endingPos, int endingIndex, int row = 0)
{
  
  
  int startIndx = startingIndex;
  
  for(int i = startingPos; i <= endingPos; i++)
  {
      lcd.setCursor(i,row);
      lcd.print(bufferLCD[startIndx]);

      startIndx++;
  }
}



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

    if(bufferLCD[0] != 'P' && bufferLCD[1] != 'P' && bufferLCD[0] != 'W' && bufferLCD[1] != 'W' && bufferLCD[0] && bufferLCD[0] != 'G' && bufferLCD[1] != 'G' && bufferLCD[0] != 'P' && bufferLCD[1] != 'P' && bufferLCD[0] != 'S' && bufferLCD[1] != 'S' && bufferLCD[0] != 'I' && bufferLCD[1] != 'I')
    {
      lcd.clear();
      // display first code

      DisplayUpdater(0,0,3,3);

      // display second code
 

      DisplayUpdater(5,4,8,7);
  
      // display third code


      DisplayUpdater(0,8,3,11,1);

    
      // display fourth code


      DisplayUpdater(5,12,8,15,1);
  
      // display too many codes code
 

      DisplayUpdater(10,16,13,19);

      // display srl num


      DisplayUpdater(10,20,15,25,1);

    }

    else if(bufferLCD[0] == 'P' || bufferLCD[1] == 'P')
    {
      // Game Paused

      lcd.clear();

      DisplayUpdater(4,0,9,5);
      
    }

     else if(bufferLCD[0] == 'I' || bufferLCD[1] == 'I')
    {
      // Game Info

      lcd.clear();


      DisplayUpdater(4,0,7,3);

      
    }

     else if(bufferLCD[0] == 'S' || bufferLCD[1] == 'S')
    {
      // Game Settings

      lcd.clear();


      DisplayUpdater(4,0,11,11);

      
    }

    else if(bufferLCD[0] == 'G' || bufferLCD[1] == 'G')
    {
      // Game Over
      lcd.clear();


      DisplayUpdater(2,0,5,3);


      DisplayUpdater(2,4,5,7,1);

      // stopwatch


       DisplayUpdater(7,8,12,13);
    }


    else if(bufferLCD[0] == 'W' || bufferLCD[1] == 'W')
    {
      // Main Menu Text
      lcd.clear();

      DisplayUpdater(0,0,13,13);

      DisplayUpdater(0,14,14,27,1);
    }


    else if(bufferLCD[0] == 'P' || bufferLCD[1] == 'P')
    {
      // Main Menu Text
      lcd.clear();

      DisplayUpdater(0,0,4,5);

      DisplayUpdater(0,6,15,21,1);
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
