# Assignment1 Report
Course: C# Development
Student ID: cc241062 
Name: Antonia Hruschka
BBC24 Group B

# Implementation
I implemented both a recursive and iterative solution. 

The recursive solution is pretty straight-forward, and uses the standard divide and conquer strategy. I added if-statements to check for the number of disks, so that 0 disks means no game, and 1 disk just gets stacked on top of the destination rod. 

The iterative solution took me a while longer.
This solution makes use of a helper function MoveDisks() to - you guessed it - move the disks! It consists of a series of if-statements that check the states of the initial and destination rods to move the disks from or to the other respectively. This function also prints the move descriptions in a fun color. 

The iterative solution makes uses stacks to simulate rods. 
It also contains all the mathematical logic that makes this solution work: 
Tower of Hanoi has certain move patterns that shift whether or not the number of disks is odd or even. There are 3 types of valid moves that repeat forever, so the solution accounts for that as well. The iterative approach makes use of loops to run through the patterns and stops when the disks are on the right rod in the right order.

The ASCII implementation makes use DrawDisks() to draw the disks, Center() to center the disks, and DrawTowers() to draw the disks stacked on top of each other. DrawTowers() gets called after every move. 

The main function contains the commands to use in the terminal to start the program. 

# Problems
It took me A WHILE to really understand the problem mathematically. Once I understood the concept and patterns behind it, everything became a lot clearer. 

I tried my best at an ASCII implementation, but was really struggling with it :,)... so the one I have is the best I could do with the time I had.
# Conclusion
This was not as bad as I thought it would be! I honestly thought I would struggle more (I kind of did with ASCII but let's not talk about that...). I liked having a real frame of reference for the problem in the form of the little browser game, because it helped me visualize and think through the steps more easily.

# Acknowledgements: 
*Sources and Repositories I used for research and reference*
https://rosettacode.org/wiki/Towers_of_Hanoi#C#
https://staael.com/blog/tower-of-hanoi
https://www.geeksforgeeks.org/dsa/iterative-tower-of-hanoi/
https://www.geeksforgeeks.org/dsa/c-program-for-tower-of-hanoi/
https://github.com/tashkoskim/TowerOfHanoi