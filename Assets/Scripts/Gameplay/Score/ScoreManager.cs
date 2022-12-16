using System;
using JescoDev.Utility.SmoothBrainTween.Plugins.Runtime.SmoothBrainTween;
using UnityEngine;

namespace Gameplay {
    public static class ScoreManager {

        public static event Action<int> OnScoreChanged;

        public static int Score { get; private set; }

        public static void ResetScore() => Score = 0;

        public static void AddScore(int score) {
            Score += score;
            OnScoreChanged.TryInvoke(Score);
        }

    }
}