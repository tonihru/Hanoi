using System.Diagnostics.Contracts;

namespace Hanoi;

class Program
{
    //Recursive Solution 
    static void TowerOfHanoiRecursive(int n, char fromRod, char toRod, char auxRod)
    {
        if (n == 0) {   //no disk, no game :(
            return;
        } else if(n == 1) { //if there is only one disk, move it to the destination Rod

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Disk " + n + " moved from " + fromRod + " to " + toRod);
            Console.ResetColor();

        } else {            //recursive solution -->the function calls itself and uses a call stack to solve the puzzle, kind of like for n=3: function(3)->function(2)->function(1)->function(0)

            TowerOfHanoiRecursive(n - 1, fromRod, auxRod, toRod);

            Console.ForegroundColor = ConsoleColor.Blue;    //oooo fun text colors
            Console.WriteLine("Disk " + n + " moved from "
                            + fromRod + " to " + toRod);
            Console.ResetColor();

        }
    }

    //Iterative solution + Helpers + ASCII
    //function to move the disks and write out their positions in the console
    static void MoveDisk(
        Stack<int> from, 
        Stack<int> to, 
        char fromRod,       //using Stacks to simulate Rods
        char toRod)

        {
            if (from.Count == 0)    //if initial Rod is empty, move place disk from toRod on top of fromRod
            {
                int disk = to.Pop();    //-> Pop: removes top element
                from.Push(disk);        //-> Push: puts element on top of the stack
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Disk {disk} moved from {toRod} to {fromRod}");
                Console.ResetColor();
            }

            else if (to.Count == 0)     //If destination Rod is empty, take top disk from fromRod and place it on toRod
            {
                int disk = from.Pop();
                to.Push(disk);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Disk {disk} moved from {fromRod} to {toRod}");
                Console.ResetColor();
            }

            else if (from.Peek() > to.Peek())   //-> Peek: look at the top     //If fromRod is bigger than toRod, take disk from fromRod and place it on toRod
            {
                int disk = to.Pop();
                from.Push(disk);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Disk {disk} moved from {toRod} to {fromRod}");
                Console.ResetColor();
            }

            else        //If the above are not true, take disk from fromRod and place on toRod
            {
                int disk = from.Pop();
                to.Push(disk);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Disk {disk} moved from {fromRod} to {toRod}");
                Console.ResetColor();
            }
        }

    //----------ASCII----------
    //helper function to print a single disk, if the rod is empty, it prints ”|"
    static void PrintDisk(int disk, int max)
    {
            if (disk == 0)
            {
                Console.Write(Center("|", max));
            }
            else
            {
                string stars = new string('*', disk * 2 - 1);
                Console.Write(Center(stars, max));
            }
    }

    //helper function to center the towers in ASCII
    static string Center(string text, int max)
    {
        int width = max * 2 + 1;
        return text.PadLeft((width + text.Length) / 2).PadRight(width);
    }

    static void DrawTowers(Stack <int>L, Stack <int> M, Stack <int> R, int n)
    {
        //converts the stacks to arrays 
        int[] lArr = L.ToArray();
        int[] mArr = M.ToArray();
        int[] rArr = R.ToArray();

        //loops through the arrays and prints the corresponding disks using *
        for (int level = 0; level < n; level++)
        {
            int lIndex = level - (n - lArr.Length);
            int mIndex = level - (n - mArr.Length);
            int rIndex = level - (n - rArr.Length);

            PrintDisk(level < lArr.Length ? lArr[level] : 0, n);
            PrintDisk(level < mArr.Length ? mArr[level] : 0, n);
            PrintDisk(level < rArr.Length ? rArr[level] : 0, n);

            Console.WriteLine();
        }
    }

    static void TowerOfHanoiIterative(int n)
    {
        Stack<int> L = new Stack<int>();
        Stack<int> M = new Stack<int>();
        Stack<int> R = new Stack<int>();

        //Pushing all Disks to L to start solving the puzzle
        for(int i = n; i >= 1; i--)
        L.Push(i); 
        DrawTowers(L, M, R, n);
        
        char s = 'L'; //s -> source Rod
        char a = 'M'; //a -> auxiliary Rod
        char d = 'R'; //d -> destination Rod

        if(n % 2 == 0)  //if n is even --> the Rods move up one 
        {
            char temp = a;
            a = d;
            d = temp;
        }
        //Tower of Hanoi has a solution of n^2-1 moves, n being the number of disks
        int moves = (int)Math.Pow(2, n) - 1; 

        //loops through until it hits the number of moves projected above
        for(int i = 1; i <= moves; i++)
        {
        if (i % 3 == 1)        //Moves repeat every 3 steps. Which Rods are used depends on the number of disks --> switching chars around. 
            MoveDisk(L, R, s, d);   //move type 1
        else if (i % 3 == 2)
            MoveDisk(L, M, s, a);   //move type 2
        else
            MoveDisk(M, R, a, d);   //move type 3
            
            DrawTowers(L, M, R, n); //prints the towers as ASCII art after every move
        }
    }

    //Calling Recursive or Iterative
    public static void Main(string[] args)
    {
        //if using just dotnet run without specifying iterative or recursive
        if (args.Length < 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please use one of the following commands:");
            Console.WriteLine("  -recursive <number of disks>");
            Console.WriteLine("  -iterative <number of disks>");
            Console.ResetColor();
            return;
        }

        //args[0] -> -recursive/-iteraive
        //args[1] -> number of disks (n) 
        string mode = args[0];
        int n = int.Parse(args[1]);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Tower of Hanoi with {n} disks\n");
        Console.ResetColor();

        if (mode == "-recursive")
        {
            Console.WriteLine("Recursive Solution:\n");

            TowerOfHanoiRecursive(n, 'L', 'R', 'M');
        }
        else if (mode == "-iterative")
        {
            Console.WriteLine("Iterative Solution:\n");
            TowerOfHanoiIterative(n);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please use dotnet run with either -recursive or -iterative and the number of disks.");
            Console.ResetColor();
        }
    }
}