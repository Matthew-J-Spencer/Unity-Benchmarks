
using UnityEngine;

public class ExternCallsBench : BenchmarkBase {

    private Transform _transform;
    
    protected override void Init() {

        _transform = transform;
        
        BenchmarkName = "Extern Call Caching";
        
        Benchmarks.Add(new BenchmarkData("Not caching", () => {
            var pos = transform.position;
            var rot = transform.rotation;
            var scale = transform.localScale;
        }));
        
        Benchmarks.Add(new BenchmarkData("Cached per test", () => {
            var t = transform;
            var pos = t.position;
            var rot = t.rotation;
            var scale = t.localScale;
        }));

        Benchmarks.Add(new BenchmarkData("Fully cached", () => {
            var pos = _transform.position;
            var rot = _transform.rotation;
            var scale = _transform.localScale;
        }));
    }
}