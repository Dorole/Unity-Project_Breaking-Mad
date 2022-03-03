using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakingMad
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] bool _isAutoPlayEnabled = false;
        public bool IsAutoPlayEnabled => _isAutoPlayEnabled;
    }
}
