using UnityEngine;
using UnityEngine.SceneManagement;

namespace BreakingMad
{
    public class BreakableBlocksManager : MonoBehaviour
    {
        [SerializeField] Transform _breakableBlocksParent;
        int _numberOfBreakableBlocks;
        int _currentSceneIndex; 

        private void Start()
        {
            Block.onBlockDestroyed += DecreaseNumberOfBlocks;

            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _numberOfBreakableBlocks = _breakableBlocksParent.childCount;
        }

        void DecreaseNumberOfBlocks(int notUsed)
        {
            _numberOfBreakableBlocks--;

            if (_numberOfBreakableBlocks <= 0)
                SceneManager.LoadScene(_currentSceneIndex + 1);
        }

        private void OnDisable()
        {
            Block.onBlockDestroyed -= DecreaseNumberOfBlocks;
        }

    }
}
