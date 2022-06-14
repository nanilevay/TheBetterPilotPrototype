unsigned long elapsedTime = 0, lastSend = 0, sendTime = 0;

// Rotary Encoder Inputs
#define CLK 2
#define DT 3
#define SW 4

int counter = 0;
int currentStateCLK;
int lastStateCLK;
String currentDir ="";
unsigned long lastButtonPress = 0;

// Sensor Inputs
const unsigned int TRIG_PIN=13;
const unsigned int ECHO_PIN=12;
const unsigned int BAUD_RATE=9600;



void setup()
{
 
  
  // Sensor Inputs

  pinMode(TRIG_PIN, OUTPUT);
  pinMode(ECHO_PIN, INPUT);
  Serial.begin(BAUD_RATE);

  
  // Set encoder pins as inputs
  pinMode(CLK,INPUT);
  pinMode(DT,INPUT);
  pinMode(SW, INPUT_PULLUP);

    Serial.begin(115200);

  // Read the initial state of CLK
  lastStateCLK = digitalRead(CLK);
  


  //Enviar sensor data a 30 FPS
  sendTime = floor(1000 / 30);
}

void loop()
{  // Sensor Readings

  digitalWrite(TRIG_PIN, LOW);
  //delayMicroseconds(2);
  digitalWrite(TRIG_PIN, HIGH);
  //delayMicroseconds(10);
  digitalWrite(TRIG_PIN, LOW);

  const unsigned long duration= pulseIn(ECHO_PIN, HIGH);
 int distance= duration/29/2;
// if(duration==0){
  // Serial.println("Warning: no pulse from sensor");
//   } 
//  else{
     // Serial.print("distance to nearest object:");
     // Serial.println(distance);
     // Serial.println(" cm");
 // }

  

  
   // Read the current state of CLK
  currentStateCLK = digitalRead(CLK);

  // If last and current state of CLK are different, then pulse occurred
  // React to only 1 state change to avoid double count
  if (currentStateCLK != lastStateCLK  && currentStateCLK == 1){

    // If the DT state is different than the CLK state then
    // the encoder is rotating CCW so decrement
    if (digitalRead(DT) != currentStateCLK) {
      counter --;
      currentDir ="CCW";
    } else {
      // Encoder is rotating CW so increment
      counter ++;
      currentDir ="CW";
    }

    }

  // Remember last CLK state
  lastStateCLK = currentStateCLK;

  // Read the button state
  int btnState = digitalRead(SW);

  //If we detect LOW signal, button is pressed
  if (btnState == LOW) {
    //if 50ms have passed since last LOW pulse, it means that the
    //button has been pressed, released and pressed again
    if (millis() - lastButtonPress > 50) {
      // Serial.println("Button pressed!");
    }

    // Remember last button press event
    lastButtonPress = millis();
  }

  elapsedTime = millis() - lastSend;

                 
  
  if(elapsedTime > sendTime)
  {
    lastSend = millis();
    
    Serial.print(digitalRead(8));
    Serial.print(" ");
    Serial.print(digitalRead(6));
    Serial.print(" ");
    Serial.print(counter);
    Serial.print(" ");
    Serial.println(distance);

    

    
  }
  delay(20);
}
