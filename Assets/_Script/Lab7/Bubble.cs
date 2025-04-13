using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    private float lifeTime = 1.5f; // Thời gian sống của quả cầu
    private bool isCollidingWithCrosshair = false; // Trạng thái va chạm với hồng tâm
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Bắt đầu Coroutine để tự hủy sau 1.5 giây
        StartCoroutine(AutoDestroy());
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Khi hồng tâm chạm vào
        if (other.CompareTag("Crosshair"))
        {
            isCollidingWithCrosshair = true;
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Khi hồng tâm rời khỏi
        if (other.CompareTag("Crosshair"))
        {
            isCollidingWithCrosshair = false;
            spriteRenderer.color = Color.white;
        }
    }

    // Hàm được gọi bởi CrosshairController khi bấm Space
    public void TryDestroy()
    {
        if (isCollidingWithCrosshair)
        {
            UIController.instance.AddScore(1);
            Destroy(gameObject);
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        // Nếu vẫn tồn tại, tự hủy
        Destroy(gameObject);
    }
}