using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(x: 0f, y: 0f, z: -10f);
            Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: desiredPosition, smoothSpeed);

            transform.position = smoothPosition;
        }
    }
}
