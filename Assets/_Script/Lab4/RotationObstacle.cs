using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    // [Range(-1, 1)]
    // [SerializeField] private float Dir = 1f;
    public enum Direction
    {
        Left = 1,
        Right = -1
    }

    [SerializeField] private Direction dir = Direction.Right;

    void Update()
    {
        this.transform.localRotation *= Quaternion.Euler(0, 0, rotationSpeed * (float)dir);
    }
}
