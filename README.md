# swedish-robot-control
Simple robot control that understand Swedish or English commands

# Requirements
Your task is to write the control logic for a robot. The robot is located inside a 2D room,
implementing the following interface:
```
public interface IRoom
{
 IPoint StartPosition { get; }
 bool Contains(IPoint position);
}
public interface IPoint
{
 int X { get; }
 int Y { get; }
}
```
The robot moves in the room by interpreting a string of commands in English:
**L** - turn left **R** - turn right **F **- move forward. Example: **LFFRFRFRFF**
It should also be possible to configure the robot to understand Swedish:
**V** - turn left **H **- turn right **G **- move forward. Example: **VGGHGHGHGG**
At the end of the command sequence, the robot should report its position *(x,y)* and the
direction it’s facing. At the start of the command sequence, the robot is always facing North.

# Example 1
We configure a square room sized **5x5** and start position *(1,2)*. Then, after executing the
instruction set **RFRFFRFRF**, the robot reports *1 3 N*.

# Example 2
We configure a circular room with radius **10**, centered around origo, and with start position
*(0,0)*. In addition, we configure the robot to run Swedish instructions. Then, after executing
the instruction set **HHGVGGVHG**, the robot reports *3 1 Ö*.

# Dictionary 
**Swedish 	English**
- Norr 		North
- Syd 		South 
- Höger 	Right
- Öst 		East 
- Väst 		West 
- Vänster 	Left
- Gå framåt Move forward

Author: Marko Mihoković
