using System.Diagnostics;

int[] arr = new int[10000000];

Random rand = new Random();

for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(-10000, 10001);
}

Stopwatch stopwatch = new Stopwatch();
int numThreads = 4;
int chunkSize = arr.Length / numThreads;
int sum = 0;

stopwatch.Start();

Parallel.For(0, numThreads, i =>
{
    int start = i * chunkSize;
    int end = (i == numThreads - 1) ? arr.Length : (i + 1) * chunkSize;
    int localSum = 0;
    for (int j = start; j < end; j++)
    {
        localSum += arr[j];
    }
    lock (arr)
    {
        sum += localSum;
    }
});

stopwatch.Stop();

Console.WriteLine("Сумма: " + sum);
Console.WriteLine("Затраченое время на расчёт: " + stopwatch.ElapsedMilliseconds + " мс");