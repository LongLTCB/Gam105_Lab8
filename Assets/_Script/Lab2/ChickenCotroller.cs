using UnityEngine;

public class ChickenCotroller : MonoBehaviour
{
    [SerializeField] GameObject prefabEgg;
    [Range(0, 50)]
    [SerializeField] private int maxEggs = 5; 
    [SerializeField] private float minForceX = -2f;
    [SerializeField] private float maxForceX = 2f;
    [SerializeField] private float minForceY = -1f;     
    [SerializeField] private float maxForceY = 1f; 
    private int totalEggsSpawned = 0; 
    private bool isSpawn = false;
    private float timer = 0f;
    private float nextSpawnTime = 0f;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        SetNextSpawnTime();
    }

    void Update()
    {
        if (totalEggsSpawned >= maxEggs) 
        {
            isSpawn = true;
            animator.SetBool("Tired", isSpawn);
            return; 
        }

        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            SpawnEgg();
            timer = 0f; 
            SetNextSpawnTime(); 
        }
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(1f, 3f);
    }

    private void SpawnEgg()
    {
        if (totalEggsSpawned < maxEggs)
        {
            GameObject newEgg = Instantiate(prefabEgg, transform.position, Quaternion.Euler(35, 50, 90));
            Rigidbody2D eggRb = newEgg.GetComponent<Rigidbody2D>();
            if (eggRb != null)
            {
                float randomForceX = Random.Range(minForceX, maxForceX);
                float randomForceY = Random.Range(minForceY, maxForceY);
                Vector2 randomForce = new Vector2(randomForceX, randomForceY);
                eggRb.AddForce(randomForce, ForceMode2D.Impulse);
            }
            
            totalEggsSpawned++;
        }
    }
}
