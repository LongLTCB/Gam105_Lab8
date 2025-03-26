using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform A, B;
    private Vector3 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = B.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, target) < 0.1f)
        {
            target = (target == A.position) ? B.position : A.position;
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
    }
}