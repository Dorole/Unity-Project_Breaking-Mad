using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakingMad
{
    public class ScoreKeeper : MonoBehaviour
    {
        //[Range(0.1f, 5f)] [SerializeField] float _gameSpeed = 1f;

        private static ScoreKeeper _instance;
        public ScoreKeeper Singleton => _instance;

        int _score = 0; 

        public int Score => _score;

        private void Awake()
        {
            //Time.timeScale = _gameSpeed;
            #region Singleton
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            #endregion
        }

        private void Start()
        {
            Block.onBlockDestroyed += AddToScore;
            LevelLoader.onGameRestarted += ResetScore;
        }

        void AddToScore(int points)
        {
            _score += points;
        }

        void ResetScore()
        {
            _score = 0;
        }

        private void OnDisable()
        {
            Block.onBlockDestroyed -= AddToScore;
            LevelLoader.onGameRestarted -= ResetScore;
        }
    }
}
