using System.Collections.Generic;

public class MovingAverage
{
    public int Size { get; set; }
    public Queue<double> Stor { get; set; }

    private double sum;

    private double avg;

    public MovingAverage(int size)
    {
        Stor = new Queue<double>();
        Size = size;
        sum = 0.0;
        avg = 0.0;
    }

    public double Next(double val)
    {
        if (Stor.Count >= Size)
        {
            sum -= Stor.Dequeue();
        }

        Stor.Enqueue(val);
        sum += val;
        avg = 1.0 * sum / Stor.Count;

        return avg;
    }
}