using System;
using UnityEngine;

public static class Benchmark
{
    public static void Run(string label, Action action, int runs = 1000)
    {
        System.Diagnostics.Stopwatch stopwatch = new();
        stopwatch.Start();
        for (int i = 0; i < runs; i++)
            action();
        stopwatch.Stop();

        Debug.Log($"{label} Average Time: {stopwatch.Elapsed.TotalMilliseconds / runs:F6} ms per search");
    }
}