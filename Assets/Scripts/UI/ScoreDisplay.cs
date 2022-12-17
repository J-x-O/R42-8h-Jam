using Gameplay;
using TMPro;
using UnityEngine;

namespace UI {
    public class ScoreDisplay : MonoBehaviour {

        [SerializeField] private string _prefix = "Score: ";
        [SerializeField] private TMP_Text _text;

        private void OnEnable() {
            HandleBlockClick(ScoreManager.Score);
            ScoreManager.OnScoreChanged += HandleBlockClick;
        }

        private void OnDisable() {
            ScoreManager.OnScoreChanged -= HandleBlockClick;
        }
        
        private void HandleBlockClick(int newValue) {
           _text.text = _prefix + newValue * 100;
        }

    }
}