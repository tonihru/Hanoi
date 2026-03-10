namespace Hanoi;

class Program
{


    static void TowerOfHanoiRecursive(int n, char fromRod, char toRod, char auxRod)
    {
        if (n == 0) {
            return;
        }
        TowerOfHanoiRecursive(n - 1, fromRod, auxRod, toRod);
        Console.WriteLine("Disk " + n + " moved from "
                          + fromRod + " to " + toRod);
        TowerOfHanoiRecursive(n - 1, auxRod, toRod, fromRod);
    }
    public static void Main(String[] args)
    {
        int n = 3;

        TowerOfHanoiRecursive(n, 'L', 'M', 'R');
    }

    static void TowerOfHanoiIterative()
    {
        
    }
}
