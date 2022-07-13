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

  pinMode(0, INPUT_PULLUP);
  pinMode(A3, INPUT_PULLUP);
  //pinMode(1, INPUT_PULLUP);
  //pinMode(2, INPUT_PULLUP);
  //pinMode(3, INPUT_PULLUP);
  //pinMode(4, INPUT_PULLUP);
  pinMode(5, INPUT_PULLUP);
  pinMode(6, INPUT_PULLUP);
  pinMode(7, INPUT_PULLUP);
  pinMode(8, INPUT_PULLUP);
  pinMode(9, INPUT_PULLUP);
  pinMode(10, INPUT_PULLUP);
  pinMode(11, INPUT_PULLUP);

  pinMode(A2, INPUT);

    Serial.begin(115200);

  // Read the initial state of CLK
  lastStateCLK = digitalRead(CLK);
  
  //Enviar sensor data a 30 FPS
  sendTime = floor(1000 / 30);
}

void loop()
{  
  
  // Sensor Readings

  digitalWrite(TRIG_PIN, LOW);
  digitalWrite(TRIG_PIN, HIGH);
  digitalWrite(TRIG_PIN, LOW);

  const unsigned long duration= pulseIn(ECHO_PIN, HIGH);
  int distance= duration/29/2;
  
   // Read the current state of CLK
  currentStateCLK = digitalRead(CLK);

  // If last and current state of CLK are different, then pulse occurred
  // React to only 1 state change to avoid double count
  if (currentStateCLK != lastStateCLK  && currentStateCLK == 1){

    // If the DT state is different than the CLK state then
    // the encoder is rotating CCW so decrement
    if (digitalRead(DT) != currentStateCLK) {
      counter --;
      currentDir = "CCW";
    } else {
      // Encoder is rotating CW so increment
      counter ++;
      currentDir = "CW";
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

    Serial.print(digitalRead(0)); // red morse button
    Serial.print(" ");
    Serial.print(digitalRead(1)); // black morse button
    Serial.print(" ");
    Serial.print(counter); // CLK TEST
    //Serial.print(digitalRead(2)); // clk encoder
    Serial.print(" ");
    Serial.print(currentDir); // DT TEST
    // Serial.print(digitalRead(3)); // dt encoder
    Serial.print(" ");
    Serial.print(digitalRead(4)); // sw encoder (button)
    Serial.print(" ");
    Serial.print(digitalRead(5)); // green button
    Serial.print(" ");
    Serial.print(digitalRead(6)); // black button
    Serial.print(" ");
    Serial.print(digitalRead(7)); // yellow button
    Serial.print(" ");
    Serial.print(digitalRead(8)); // red button
    Serial.print(" ");
    Serial.print(digitalRead(9)); // blue button
    Serial.print(" ");
    Serial.print(counter); // rotator value
    Serial.print(" ");
    Serial.print(digitalRead(10)); // toggle 1
    Serial.print(" ");
    Serial.print(digitalRead(11)); // toggle 2
    Serial.print(" ");
    Serial.print(analogRead(A2)); // slider
    Serial.print(" ");
    Serial.println(distance); // distance sensor  
    
  }
  delay(20);
}
