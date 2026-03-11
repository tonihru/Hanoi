namespace Hanoi;

class Program
{

    static void TowerOfHanoiRecursive(int n, char fromRod, char toRod, char auxRod)
    {
        if (n == 0) {
            return;
        } else if(n == 1) {
            Console.WriteLine("Disk " + n + " moved from " + fromRod + " to " + toRod);
        } else {
            TowerOfHanoiRecursive(n - 1, fromRod, auxRod, toRod);
            Console.WriteLine("Disk " + n + " moved from "
                            + fromRod + " to " + toRod);
            TowerOfHanoiRecursive(n - 1, auxRod, toRod, fromRod);
        }
    }
    public static void Main(String[] args)
    {

        TowerOfHanoiRecursive(4, 'L', 'M', 'R');
        
        TowerOfHanoiIterative(3);
    }


    static void MoveDisk(
        Stack<int> from, 
        Stack<int> to, 
        char fromRod, 
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

        for(int i = n; i >= 1; i--)
        L.Push(i);
        
        char s = 'L'; //s -> source Rod
        char a = 'M'; //a -> auxiliary Rod
        char d = 'R'; //d -> destination Rod

        if(n % 2 == 0)
        {
            char temp = a;
            a = d;
            d = temp;
        }
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
}
