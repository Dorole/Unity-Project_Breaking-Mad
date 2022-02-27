using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakingMad
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] PaddleMovement _paddle;
        [SerializeField] Vector2 _launchVector = new Vector2();

        Vector2 _paddleToBallVector;
        Rigidbody2D _rb;
        bool _isLaunched = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _paddleToBallVector = transform.position - _paddle.transform.position;    
        }

        private void Update()
        {
            if (!_isLaunched)
            {
                LockBallToPaddle();
                LaunchOnMouseClick();
            }
        }

        void LockBallToPaddle()
        {
            Vector2 paddlePos = new Vector2(_paddle.transform.position.x, _paddle.transform.position.y);
            transform.position = paddlePos + _paddleToBallVector;
        }

        void LaunchOnMouseClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isLaunched = true;
                _rb.velocity = _launchVector;
            }
        }
    }
}
