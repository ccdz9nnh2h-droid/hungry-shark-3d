using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -8);
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float rotationSpeed = 3f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        Vector3 lookAtTarget = target.position + Vector3.up * 1.5f;
        transform.LookAt(lookAtTarget);
    }
}
