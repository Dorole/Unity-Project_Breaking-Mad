using UnityEngine;
using UnityEngine.SceneManagement;

namespace BreakingMad
{
    public class LoseCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
