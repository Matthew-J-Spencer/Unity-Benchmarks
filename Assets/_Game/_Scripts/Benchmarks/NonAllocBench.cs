using UnityEngine;

public class NonAllocBench : BenchmarkBase {
    private const float RADIUS = 10;
    private readonly Collider[] _collisions = new Collider[100];
    
    protected override void Init() {
        MaxRecommendedIterations = 250000;
        BenchmarkName = "NonAlloc";

        Benchmarks.Add(new BenchmarkData("OverlapSphere", () => {
            var result = Physics.OverlapSphere(transform.position, RADIUS);
        }));
        
        Benchmarks.Add(new BenchmarkData("OverlapSphereNonAlloc", () => {
            var result = Physics.OverlapSphereNonAlloc(transform.position, RADIUS, _collisions);
        }));
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position,RADIUS);
    }
}
