using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float lerpTime = 0.1f;
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private Vector3 _velocity = Vector3.zero;
        private Vector3 _moveToPosition;

        private void Start()
        {
            transform.position = CalculateMoveToPosition();
        }

        private void Update()
        {
            _moveToPosition = CalculateMoveToPosition();
            transform.position = Vector3.SmoothDamp(transform.position, _moveToPosition, ref _velocity, lerpTime);
        }

        private Vector3 CalculateMoveToPosition()
        {
            return target.position + offset;
        }
    }
}