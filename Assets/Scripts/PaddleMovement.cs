using UnityEngine;

namespace BreakingMad
{
    public class PaddleMovement : MonoBehaviour
    {
        [SerializeField] float _screenWidthUnits = 16f;
        [SerializeField] float _paddlePosLeftLimit = 1f;
        [SerializeField] float _paddlePosRightLimit = 8f;

        private void Update()
        {
            FollowMouseOnX();
        }

        void FollowMouseOnX()
        {
            float mousePosInUnits = (Input.mousePosition.x / Screen.width) * _screenWidthUnits;
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(mousePosInUnits, _paddlePosLeftLimit, _paddlePosRightLimit);
            transform.position = paddlePos;
        }
    }
}
