

int notes[] = {262, 294, 330, 249};

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  int keyVal = analogRead(A0);
  Serial.println(keyVal);
  
  if (keyVal == 1023) {
    tone(8, notes[0]);
  }
  else if (keyVal >= 990 && keyVal <= 1010){
    tone(8, notes[1]);
  }
  else if (keyVal >= 505 && keyVal <= 515) {
     tone(8, notes[2]);
  }
  else if(keyVal >= 1 && keyVal <= 15) {
    tone(8, notes[3]);
  }
  else {
   noTone(8);
   } 
}
