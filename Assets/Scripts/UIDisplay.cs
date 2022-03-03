using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BreakingMad
{
    public class UIDisplay : MonoBehaviour
    {
        ScoreKeeper _gameStatus;
        [SerializeField] TextMeshProUGUI _scoreText;

        private void Start()
        {
            _gameStatus = FindObjectOfType<ScoreKeeper>();

            Block.onBlockDestroyed += UpdateScore;
            LevelLoader.onGameRestarted += ResetScore;
        }

        void UpdateScore(int notUsed)
        {
            _scoreText.text = _gameStatus.Score.ToString("000000000");
        }

        void ResetScore()
        {
            _scoreText.text = _gameStatus.Score.ToString("000000000");
        }
    }
}
