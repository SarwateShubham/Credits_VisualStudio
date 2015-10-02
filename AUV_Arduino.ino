#define fwd 'f'
#define left 'l'
#define right 'r'
#define dive 'd'
#define _stop 's'
#define high_velo 'q'
#define low_velo 'a'

#include <Servo.h>

Servo fw_left;
Servo fw_right;
Servo dive_left;
Servo dive_right;
int velo=0;
char input=0;
void setup()
{
fw_left.attach(11);
fw_right.attach(10);
dive_left.attach(9);
dive_right.attach(6);
}

void loop()
{
  if(Serial.available()!=0)
  {
    input =Serial.read();
    if(input==high_velo)
      velo=175;
    else if(input==low_velo)
      velo=55;
    else if(input==fwd)
    {
      fw_left.write(velo);
      fw_right.write(velo);
      dive_left.write(0);
      dive_right.write(0);
    }
    else if(input==left)
    {
      fw_left.write(0);
      fw_right.write(velo);
      dive_left.write(0);
      dive_right.write(0); 
    }
     else if(input==right)
    {
      fw_left.write(velo);
      fw_right.write(0);
      dive_left.write(0);
      dive_right.write(0); 
    }
    else if(input==dive)
    {
      fw_left.write(0);
      fw_right.write(0);
      dive_left.write(velo);
      dive_right.write(velo); 
    }
    else if(input==_stop)
    {
      fw_left.write(0);
      fw_right.write(0);
      dive_left.write(0);
      dive_right.write(0); 
    }
  }
  Serial.flush();
}
