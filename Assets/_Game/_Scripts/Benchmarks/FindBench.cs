using UnityEngine;

public class FindBench : BenchmarkBase {
    private const int TREE_COUNT = 50;
    private const int LAYER_COUNT = 50;
    private const int OBJECTS_PER_LAYER = 5;

    protected override void Init() {
        MaxRecommendedIterations = 1000;

        var last = transform;
        for (int i = 0; i < TREE_COUNT; i++) {
            var treeObj = new GameObject($"Tree {i}");
            treeObj.transform.SetParent(last);
            for (int j = 0; j < LAYER_COUNT; j++) {
                var layerObj = new GameObject($"Layer {j}");
                layerObj.transform.SetParent(treeObj.transform);
                for (int k = 0; k < OBJECTS_PER_LAYER; k++) {
                    var obj = new GameObject($"Obj {k}") {
                        tag = "Find"
                    };
                    obj.AddComponent<FindHelper>();
                    obj.transform.SetParent(layerObj.transform);
                }
            }
        }

        BenchmarkName = "Find Objects";

        Benchmarks.Add(new BenchmarkData("FindGameObjectsWithTag", () => {
            var values = GameObject.FindGameObjectsWithTag("Find");
        }));


        Benchmarks.Add(new BenchmarkData("FindObjectsOfType", () => {
            var values = FindObjectsOfType<FindHelper>();
        }));
    }
}