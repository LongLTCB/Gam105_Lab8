using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform A, B;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject prefabEnemy;
    private Vector3 target;
    private int count = 0;
    private bool hasSpawned = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = B.position;
    }

    // Update is called once per frame
    void Update()
    {
        count++; 

        if (count > 1000)
        {
            target = player.position;
            
            if (!hasSpawned)
            {
                Vector3 spawnPosition = transform.position + new Vector3(1f, 1f, 0); 
                Instantiate(prefabEnemy, spawnPosition, Quaternion.identity);
                hasSpawned = true;
            }
        }
        else
        {
            if (Vector2.Distance(this.transform.position, target) < 0.1f)
            {
                target = (target == A.position) ? B.position : A.position;
            }
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}