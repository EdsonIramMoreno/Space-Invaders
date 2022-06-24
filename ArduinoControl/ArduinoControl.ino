 const int LedPin=12;
 const int boton=8;
 int Equis;
 
void setup() {
  Serial.begin(9600);
  pinMode(boton,INPUT);
  pinMode(LedPin,OUTPUT);
}

void loop() {
     Equis = analogRead(A1);
     if(digitalRead(boton) == LOW){   
     Serial.println("Shot");
     }
     else{
      Serial.println(Equis);
     }
     TurnLedOn();
 delay(100);
}

void TurnLedOn(){
    if(Serial.available()){
   int data;
     data=Serial.read();
    if(data=='A'){
      digitalWrite(LedPin,HIGH);
      }
      else{
        digitalWrite(LedPin,LOW);
      }
   }
}
