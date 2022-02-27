using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakingMad
{
    public class Block : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}
