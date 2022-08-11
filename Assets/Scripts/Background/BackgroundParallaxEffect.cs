using UnityEngine;

namespace Background
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundParallaxEffect : MonoBehaviour
    {
        [SerializeField] private float parallaxEffectSpeed;
        [SerializeField] private Transform camera;

        private float _spriteLength;
        private float _startPositionX;

        private void Start()
        {
            _startPositionX = transform.position.x;
            _spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            var distance = camera.position.x * parallaxEffectSpeed;
            transform.position = new Vector3(_startPositionX + distance, transform.position.y,
                transform.position.z);

            var temp = camera.position.x * (1 - parallaxEffectSpeed);
            if (temp > _startPositionX + _spriteLength)
            {
                _startPositionX += _spriteLength;
            }
            else if (temp < _startPositionX - _spriteLength)
            {
                _startPositionX -= _spriteLength;
            }
        }
    }
}