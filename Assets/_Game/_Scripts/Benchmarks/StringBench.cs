using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StringBench : BenchmarkBase {
    private const int COUNT = 100;
    private const string PHRASE = "Subscribe :) ";
    protected override void Init() {
        BenchmarkName = "String Builder";
        MaxRecommendedIterations = 3000;
        
        Benchmarks.Add(new BenchmarkData("Concatenation", () => {
            var value = "";
            for (int i = 0; i < COUNT; i++) {
                value += PHRASE;
            }
        }));
        
        Benchmarks.Add(new BenchmarkData("Builder", () => {
            var builder = new StringBuilder();
            for (int i = 0; i < COUNT; i++) {
                builder.Append(PHRASE);
            }

            var value = builder.ToString();
        }));
    }
}
