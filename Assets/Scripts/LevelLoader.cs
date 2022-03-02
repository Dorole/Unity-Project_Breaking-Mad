using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BreakingMad
{
    public class LevelLoader : MonoBehaviour
    {
        public static event Action onGameRestarted;

        private void Awake()
        {
            CheckForRestart();
        }

        void CheckForRestart()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.buildIndex == 1) 
                onGameRestarted?.Invoke();
        }

        public void LoadLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
