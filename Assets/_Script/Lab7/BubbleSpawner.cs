using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject[] bubblePrefabs; // Mảng chứa 10 Prefabs quả cầu
    public float spawnInterval = 2f; // Thời gian giữa các lần sinh quả cầu

    void Start()
    {
        // Kiểm tra mảng Prefabs
        if (bubblePrefabs.Length == 0)
        {
            Debug.LogError("Bubble Prefabs array is empty!");
            return;
        }

        // Bắt đầu Coroutine để sinh quả cầu
        StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        while (true)
        {
            // Sinh vị trí ngẫu nhiên trong khu vực
            float RandomX = Random.Range(-5, 5);
            Vector3 spawnPosition = new Vector3(x: RandomX, y: -5f, z:  0f);

            // Chọn ngẫu nhiên một Prefab từ mảng
            int randomIndex = Random.Range(0, bubblePrefabs.Length);
            GameObject selectedPrefab = bubblePrefabs[randomIndex];

            // Tạo quả cầu từ Prefab được chọn
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            // Đợi một khoảng thời gian trước khi sinh quả cầu tiếp theo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}