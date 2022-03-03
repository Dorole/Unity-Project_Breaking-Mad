using UnityEngine;
using System;

namespace BreakingMad
{
    public class Block : MonoBehaviour
    {
        public static event Action<int> onBlockDestroyed;

        [SerializeField] AudioClip _breakSound;
        [SerializeField] GameObject _particleEffect;
        [SerializeField] int _points;
        [SerializeField] int _maxHits;
        [SerializeField] Sprite[] _hitSprites;
        
        int _timesHit;
        SpriteRenderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Breakable"))
                HandleHit();
        }

        void HandleHit()
        {
            _timesHit++;

            if (_timesHit == _maxHits)
                DestroyBlock();
            else
                ChangeHitSprite();
        }

        void ChangeHitSprite()
        {
            int spriteIndex = _timesHit - 1;
            try
            { 
                _renderer.sprite = _hitSprites[spriteIndex];
            }
            catch (Exception e)
            {
                Debug.LogWarning("Block sprite is missing from array" + gameObject.name);
                return;
            }
        }

        void DestroyBlock()
        {
            onBlockDestroyed?.Invoke(_points);
            
            AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
            TriggerParticleEffect();

            Destroy(gameObject);
        }

        void TriggerParticleEffect()
        {
            GameObject effect = Instantiate(_particleEffect, transform.position, transform.rotation);
            Destroy(effect, 1.5f);
        }
    }
}
