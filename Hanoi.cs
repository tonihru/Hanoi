namespace Hanoi;

class Program
{
    //Recursive Solution 
    static void TowerOfHanoiRecursive(int n, char fromRod, char toRod, char auxRod)
    {
        if (n == 0) {   //no disk, no game :(
            return;
        } else if(n == 1) { //if there is only one disk, move it to the destination Rod
            Console.WriteLine("Disk " + n + " moved from " + fromRod + " to " + toRod);
        } else {            //recursive solution -->the function calls itself and uses a call stack to solve the puzzle, kind of like for n=3: function(3)->function(2)->function(1)->function(0)
            TowerOfHanoiRecursive(n - 1, fromRod, auxRod, toRod);
            Console.WriteLine("Disk " + n + " moved from "
                            + fromRod + " to " + toRod);
            TowerOfHanoiRecursive(n - 1, auxRod, toRod, fromRod);
        }
    }

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
                Console.WriteLine($"Disk {disk} moved from {toRod} to {fromRod}");
            }

            else if (to.Count == 0)     //If destination Rod is empty, take top disk from fromRod and place it on toRod
            {
                int disk = from.Pop();
                to.Push(disk);
                Console.WriteLine($"Disk {disk} moved from {fromRod} to {toRod}");
            }

            else if (from.Peek() > to.Peek())   //-> Peek: look at the top     //If fromRod is bigger than toRod, take disk from fromRod and place it on toRod
            {
                int disk = to.Pop();
                from.Push(disk);
                Console.WriteLine($"Disk {disk} moved from {toRod} to {fromRod}");
            }

            else        //If the above are not true, take disk from fromRod and place on toRod
            {
                int disk = from.Pop();
                to.Push(disk);
                Console.WriteLine($"Disk {disk} moved from {fromRod} to {toRod}");
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
        }
    }

    //Calling Recursive or Iterative
    public static void Main(string[] args)
{
    if (args.Length < 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Usage:");
        Console.WriteLine("  -recursive <number_of_disks>");
        Console.WriteLine("  -iterative <number_of_disks>");
        Console.ResetColor();
        return;
    }

    string mode = args[0];
    int n = int.Parse(args[1]);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Tower of Hanoi with {n} disks\n");
    Console.ResetColor();

    if (mode == "-recursive")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Running Recursive Solution:\n");
        Console.ResetColor();

        TowerOfHanoiRecursive(n, 'L', 'R', 'M');
    }
    else if (mode == "-iterative")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Running Iterative Solution:\n");
        TowerOfHanoiIterative(n);
        Console.ResetColor();

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unknown argument. Use -recursive or -iterative.");
        Console.ResetColor();
    }
}
}
