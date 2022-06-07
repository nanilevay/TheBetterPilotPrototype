#include <FastLED.h>

#define LED_PIN     6
#define NUM_LEDS    10
#define BRIGHTNESS  200


CRGB leds[NUM_LEDS];


char bufferLCD[32];
byte bufferLED[NUM_LEDS*3];

void setup()
{
  delay(3000); // sanity delay
  
  Serial.begin(115200);
      
  FastLED.addLeds<WS2812B, LED_PIN, GRB>(leds, NUM_LEDS).setCorrection( TypicalLEDStrip );
  FastLED.setBrightness( BRIGHTNESS );
  FastLED.clear();
  FastLED.show();
}

// https://www.arduino.cc/reference/en/language/functions/communication/serial/

void loop()
{  
  while (Serial.available() > 0)
  {

    //Para ser 1 byte (que vai controlar o servo)
    //byte servo = Serial.read();

    //Para ler 32 bytes (16x2) para o LCD
    //Serial.readBytes(bufferLCD, 32);

    //Para ler 3 bytes por LED
    Serial.readBytes(bufferLED, NUM_LEDS*3);

    //Para percorrer lista de LEDs e atribuir a cada a cor que recebemos do Unity
    for(int i = 0; i < NUM_LEDS; i++)
    {
      int index = i * 3;
      byte r = bufferLED[index+0]; // :)
      byte g = bufferLED[index+1];
      byte b = bufferLED[index+2];
      
      CRGB color = CRGB(r, g, b, w);
      leds[i] = color;
    }

    //Para de facto enviar cores para os LEDs
    FastLED.show();
  }

  //delay(20);
}
