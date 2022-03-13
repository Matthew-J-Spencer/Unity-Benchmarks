using TMPro;
using UnityEngine;

public class BenchmarkButton : MonoBehaviour {
    [SerializeField] private TMP_Text _buttonText;
    public void Init(string btnText) {
        _buttonText.text = btnText;
    }
}