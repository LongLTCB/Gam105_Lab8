using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    float runtime = 0;
    bool isRespawning = false, isPlayerDir = false;
    GameObject enemy;
    Vector3 PlayerDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        runtime += Time.deltaTime;
        if (!isRespawning)
        {
            enemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            isRespawning = true;
        }
        if (runtime > 10f)
        {
            if (!isPlayerDir)
            {
                PlayerDir = GameObject.FindWithTag("Player").transform.position;
                isPlayerDir = true;
            }

            if (Vector2.Distance(enemy.transform.position, PlayerDir) > 0.1f)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, PlayerDir, 5f * Time.deltaTime);
            }

            if (Vector2.Distance(enemy.transform.position, PlayerDir) < 0.1f)
            {
                Destroy(enemy, 0.5f);
                isRespawning = false;
                isPlayerDir = false;
                runtime = 0;
            }
        }
    }
}