using UnityEngine;

public class FollowTargetPositionX : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;

    private Vector3 _moveToPosition;

    private void Start()
    {
        _moveToPosition = new Vector3();
    }

    private void Update()
    {
        _moveToPosition.x = targetPosition.position.x;
        _moveToPosition.y = transform.position.y;
        _moveToPosition.z = transform.position.z;
        transform.position = _moveToPosition;
    }
}