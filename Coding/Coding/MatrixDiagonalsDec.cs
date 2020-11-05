using System.Threading;

public class MatrixDiagonalsDec
{
    private static Mutex mutex = new Mutex();

    private static int[,] Mat;

    public MatrixDiagonalsDec(int[,] mat)
    {
        Mat = mat;
    }

    public static void TProcess(object i)
    {
        System.Console.WriteLine("{0} is requesting the mutex", 
                          Thread.CurrentThread.Name);
        System.Console.WriteLine($"Getting Mutex");
        mutex.WaitOne();
        System.Console.WriteLine("{0} has entered the protected area", 
                          Thread.CurrentThread.Name);
        System.Console.WriteLine($"Got Mutex");
        for (int j = 1; j < Mat.GetLength(1); j++)
        {
            if (Mat[(int)i - 1, j - 1] <= Mat[(int)i, j])
            {
                System.Console.WriteLine(false);
            }
        }
        System.Console.WriteLine("{0} is leaving the protected area", 
            Thread.CurrentThread.Name);
        System.Console.WriteLine($"release Mutex");
        mutex.ReleaseMutex();
        System.Console.WriteLine($"released Mutex");
        System.Console.WriteLine("{0} has released the mutex", 
            Thread.CurrentThread.Name);
    }

    public bool Run()
    {
        if (Mat == null)
        {
            return false;
        }

        for (int i = 1; i < Mat.GetLength(0); i++)
        {
            var t = new Thread(new ParameterizedThreadStart(TProcess));
            t.Name = string.Format("Thread{0}", i + 1);
            t.Start(i);
        }

        return true;
    }
}