using Vector3 = UnityEngine.Vector3;

public class DistanceBench : BenchmarkBase {
    private readonly Vector3 _a = new(1038, 2819.43f, 103);
    private readonly Vector3 _b = new(632.34f, 12.1f, 9238.98f);
    
    protected override void Init() {
        BenchmarkName = "Distance";
        
        Benchmarks.Add(new BenchmarkData("Vector3.Distance", () => {
            var value = Vector3.Distance(_a, _b);
        }));
        Benchmarks.Add(new BenchmarkData("Square Magnitude", () => {
            var value =  (_a - _b).sqrMagnitude;
        }));
    }
}