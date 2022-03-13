using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqBench : BenchmarkBase {
    private const int COUNT = 10000;
    private const int THRESHOLD = 5000;
    private readonly List<LinqData> _data = new();

    protected override void Init() {
        BenchmarkName = "Linq vs Loop";
        MaxRecommendedIterations = 1000;
        
        for (int i = 0; i < COUNT; i++) {
            _data.Add(new LinqData() {
                Value = Random.Range(0, 1000000),
                ValueTwo = Random.Range(0f, 1000000f)
            });
        }

        Benchmarks.Add(new BenchmarkData("Linq", () => {
            var values = _data.Where(d => d.Value > THRESHOLD).Select(v => v.ValueTwo).ToList();
        }));
        
        Benchmarks.Add(new BenchmarkData("For", () => {
            var values = new List<float>();
            for (int i = 0; i < _data.Count; i++) {
                if(_data[i].Value > THRESHOLD) values.Add(_data[i].ValueTwo);
            }
        }));
        
        Benchmarks.Add(new BenchmarkData("Cached for", () => {
            var values = new List<float>();
            var count = _data.Count;
            for (int i = 0; i < count; i++) {
                if(_data[i].Value > THRESHOLD) values.Add(_data[i].ValueTwo);
            }
        }));
        
        Benchmarks.Add(new BenchmarkData("Foreach", () => {
            var values = new List<float>();
            foreach (var data in _data) {
                if(data.Value > THRESHOLD) values.Add(data.ValueTwo);
            }
        }));
    }

    private struct LinqData {
        public int Value;
        public float ValueTwo;
    }
}