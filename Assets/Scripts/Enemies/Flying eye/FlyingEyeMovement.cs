using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Flying_eye
{
    public class FlyingEyeMovement : MonoBehaviour
    {
        [SerializeField] private float flySpeed = 30f;
        [SerializeField] private Transform route;

        public delegate void OnMoveRight();

        public event OnMoveRight MoveRight;

        public delegate void OnMoveLeft();

        public event OnMoveLeft MoveLeft;

        private List<Vector3> _wayPoints;
        private int _currentWayPointIndex;
        private bool _isOnTheWayBack;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _wayPoints = new List<Vector3>();
            for (var i = 0; i < route.childCount; i++)
            {
                _wayPoints.Add(route.GetChild(i).transform.position);
            }

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_wayPoints.Count < 2) return;

            if (transform.position.x < _wayPoints[_currentWayPointIndex].x)
            {
                MoveRight?.Invoke();
            }
            else
            {
                MoveLeft?.Invoke();
            }

            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPointIndex],
                flySpeed * Time.deltaTime);

            if (transform.position == _wayPoints[_currentWayPointIndex])
            {
                if (_isOnTheWayBack)
                {
                    _currentWayPointIndex--;
                }
                else
                {
                    _currentWayPointIndex++;
                }

                if (!_isOnTheWayBack && _currentWayPointIndex == _wayPoints.Count - 1)
                {
                    _isOnTheWayBack = true;
                }
                else if (_isOnTheWayBack && _currentWayPointIndex == 0)
                {
                    _isOnTheWayBack = false;
                }
            }
        }

        public void TeleportToStartPosition()
        {
            if (_wayPoints.Count == 0) return;
            transform.position = _wayPoints[0];
            _currentWayPointIndex = 1;
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}