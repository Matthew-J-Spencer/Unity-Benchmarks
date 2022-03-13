using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// I made this mono in case future tests required it
/// </summary>
public abstract class BenchmarkBase : MonoBehaviour {
    public string BenchmarkName { get; protected set; }
    public int MaxRecommendedIterations { get; protected set; } = int.MaxValue;
    protected readonly List<BenchmarkData> Benchmarks = new();

    public IEnumerable<BenchmarkData> RunBenchmark(int iterations) {
        foreach (var benchmark in Benchmarks) {
            yield return Run(benchmark);
        }

        BenchmarkData Run(BenchmarkData data) {
            var watch = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++) {
                data.Action();
            }

            watch.Stop();
            data.Result = watch.ElapsedMilliseconds;
            return data;
        }
    }

    private void Awake() => Init();

    protected abstract void Init();
}

public struct BenchmarkData {
    public readonly string Name;
    public readonly Action Action;
    public long Result;

    public BenchmarkData(string name, Action action) {
        Name = name;
        Action = action;
        Result = 0;
    }
}