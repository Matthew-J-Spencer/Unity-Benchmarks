using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Integer math is faster than floating point, which is faster than vector
/// https://docs.unity3d.com/Manual/BestPracticeUnderstandingPerformanceInUnity7.html
/// </summary>
public class OrderOfOperation : BenchmarkBase {
    private readonly Vector3 _vector3 = new(789, 123, 456);

    private const float MULTIPLIER = 2035.72f;

    protected override void Init() {
        BenchmarkName = "Order of Operation";

        Benchmarks.Add(new BenchmarkData("FxFxV", () => {
            var result = MULTIPLIER * MULTIPLIER * _vector3;
        }));

        Benchmarks.Add(new BenchmarkData("FxVxF", () => {
            var result = MULTIPLIER * _vector3 * MULTIPLIER;
        }));

        Benchmarks.Add(new BenchmarkData("VxFxF", () => {
            var result = _vector3 * MULTIPLIER * MULTIPLIER;
        }));

    }
}