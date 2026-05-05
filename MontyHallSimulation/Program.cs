using System.Diagnostics;
using System.Security.Cryptography;

var iterations = args.Length > 0 && int.TryParse(args[0], out var n) ? n : CalibrateIterations();

var stayWins = 0;
var switchWins = 0;

var sw = Stopwatch.StartNew();

for (var i = 0; i < iterations; i++)
{
    var car = RandomNumberGenerator.GetInt32(3);
    var firstChoice = RandomNumberGenerator.GetInt32(3);

    // Host opens a goat door among doors not chosen and not containing the car.
    var opened = Enumerable.Range(0, 3).First(d => d != firstChoice && d != car);

    // Staying keeps firstChoice.
    if (firstChoice == car)
        stayWins++;

    // Switching chooses the only remaining closed door.
    var switchedChoice = Enumerable.Range(0, 3).First(d => d != firstChoice && d != opened);
    if (switchedChoice == car)
        switchWins++;
}

sw.Stop();

Console.WriteLine($"Iterations: {iterations:N0}");
Console.WriteLine($"Time:       {sw.Elapsed}");
Console.WriteLine($"Stay:       {100.0 * stayWins / iterations:F2}%");
Console.WriteLine($"Switch:     {100.0 * switchWins / iterations:F2}%");

static int CalibrateIterations()
{
    const int sample = 100_000;
    var sw = Stopwatch.StartNew();

    for (var i = 0; i < sample; i++)
    {
        RandomNumberGenerator.GetInt32(3);
        RandomNumberGenerator.GetInt32(3);
    }

    sw.Stop();

    var perSecond = sample / sw.Elapsed.TotalSeconds;
    return Math.Max(1_000_000, (int)(perSecond * 5));
}