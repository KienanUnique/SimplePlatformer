using UnityEngine;

namespace Flying_eye
{
    public class FlyingEyeMovement : MonoBehaviour
    {
        [SerializeField] private float flySpeed = 30f;
        [SerializeField] private Transform[] wayPoints;
        
        public delegate void OnMoveRight();

        public event OnMoveRight MoveRight;

        public delegate void OnMoveLeft();

        public event OnMoveLeft MoveLeft;

        private int _currentWayPointIndex;

        private void Update()
        {
            if (wayPoints.Length == 0) return;

            if (transform.position.x < wayPoints[_currentWayPointIndex].position.x)
            {
                MoveRight?.Invoke();
            }
            else
            {
                MoveLeft?.Invoke();
            }
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[_currentWayPointIndex].position,
                flySpeed * Time.deltaTime);
        
            if (transform.position == wayPoints[_currentWayPointIndex].position)
            {
                if (_currentWayPointIndex + 1 < wayPoints.Length)
                {
                    _currentWayPointIndex++;
                }
                else
                {
                    _currentWayPointIndex = 0;
                }
            }
        }
    }
}