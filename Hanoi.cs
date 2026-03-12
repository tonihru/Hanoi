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
        } else {            //recursive solution -->the function calls itself and uses a call stack to solve the puzzle, kind of like function(3)->function(2)->function(1)->function(0)
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
            if (from.Count == 0)
            {
                int disk = to.Pop();
                from.Push(disk);
                Console.WriteLine($"Disk {disk} moved from {toRod} to {fromRod}");
            }

            else if (to.Count == 0)
            {
                int disk = from.Pop();
                to.Push(disk);
                Console.WriteLine($"Disk {disk} moved from {fromRod} to {toRod}");
            }

            else if (from.Peek() > to.Peek())
            {
                int disk = to.Pop();
                from.Push(disk);
                Console.WriteLine($"Disk {disk} moved from {toRod} to {fromRod}");
            }

            else
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
        //Tower of Hanoi has a solution of n^2-1, n being the number of disks
        int moves = (int)Math.Pow(2, n) - 1; 

        for(int i = 1; i <= moves; i++)
        {
        if (i % 3 == 1)
            MoveDisk(L, R, s, d);
        else if (i % 3 == 2)
            MoveDisk(L, M, s, a);
        else
            MoveDisk(M, R, a, d);
        }
    }

    //Calling Recursive or Iterative
    public static void Main(String[] args)
    {

        TowerOfHanoiRecursive(4, 'L', 'M', 'R');

        TowerOfHanoiIterative(3);
    }
}
