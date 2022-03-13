using UnityEngine;

public class CameraBench : BenchmarkBase {

    private Camera _cam;
    protected override void Init() {
        BenchmarkName = "Camera Access";
        
        _cam = Camera.main;

        Benchmarks.Add(new BenchmarkData("Camera.main", () => {
            var cam = Camera.main;
            var aspect = cam.aspect;
        }));
        
        Benchmarks.Add(new BenchmarkData("FindWithTag", () => {
            var cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            var aspect = cam.aspect;
        }));
        
        Benchmarks.Add(new BenchmarkData("FindObjectOfType", () => {
            var cam = FindObjectOfType<Camera>();
            var aspect = cam.aspect;
        }));
        
        Benchmarks.Add(new BenchmarkData("Cached Camera", () => {
            var aspect = _cam.aspect;
        }));
    }

}
