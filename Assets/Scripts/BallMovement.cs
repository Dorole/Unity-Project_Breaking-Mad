using UnityEngine;

namespace BreakingMad
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] PaddleMovement _paddle;
        [SerializeField] Vector2 _launchVector = new Vector2();
        [SerializeField] float _randomFactor = 0.2f;

        Vector2 _paddleToBallVector;
        Rigidbody2D _rb;
        bool _isLaunched = false;

        //move elsewhere
        [SerializeField] AudioClip[] _ballSounds;
        AudioSource _sound;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sound = GetComponent<AudioSource>();
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(0, _randomFactor), Random.Range(0, _randomFactor));

            if (_isLaunched)
            {
                PlayRandomSound();
                _rb.velocity += velocityTweak;
            }
        }

        void PlayRandomSound()
        {
            AudioClip clip = _ballSounds[Random.Range(0, _ballSounds.Length)];
            _sound.PlayOneShot(clip);
        }
    }
}
