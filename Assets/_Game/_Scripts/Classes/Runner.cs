using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Runner : MonoBehaviour {
    [SerializeField] private TMP_Text _resultText;

    [SerializeField] private Slider _iterationSlider;
    [SerializeField] private TMP_Text _iterationText;
    [SerializeField] private Transform _buttonParent;
    [SerializeField] private BenchmarkButton _btnPrefab;

    private BenchmarkBase _confirmBenchmark;

    private int Iterations => (int)_iterationSlider.value;

    private void Start() {
        _iterationSlider.onValueChanged.AddListener(f => _iterationText.text = f.ToString("N0"));
        _iterationSlider.value = 500000;

        foreach (var benchmark in GetComponentsInChildren<BenchmarkBase>()) {
            var btn = Instantiate(_btnPrefab, _buttonParent);
            btn.Init(benchmark.BenchmarkName);

            btn.GetComponent<Button>().onClick.AddListener(() => {
                if (Iterations > benchmark.MaxRecommendedIterations && _confirmBenchmark != benchmark) {
                    _confirmBenchmark = benchmark;
                    _iterationSlider.value = benchmark.MaxRecommendedIterations;
                    _resultText.text = $"<color=red>Max recommended iterations for this benchmark is {benchmark.MaxRecommendedIterations}. Click the button again to confirm any count (This may crash your {(Application.platform == RuntimePlatform.WebGLPlayer ? "browser" : "computer")})";
                }
                else {
                    _confirmBenchmark = null;
                    RunBenchmarks(benchmark);
                }
            });
        }
    }

    private void RunBenchmarks(BenchmarkBase benchmark) {
        var builder = new StringBuilder();
        builder.Append($"<color=orange>{benchmark.BenchmarkName} x {Iterations}</color>\n");
        foreach (var result in benchmark.RunBenchmark(Iterations)) {
            builder.Append($"{result.Name}: {result.Result}\n");
        }

        _resultText.text = builder.ToString();
    }
}