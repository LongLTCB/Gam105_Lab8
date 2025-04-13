using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của hồng tâm (không dùng vì di chuyển bằng chuột)

    void Update()
    {
        // Di chuyển hồng tâm theo chuột
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Đặt z = 0 vì là game 2D
        transform.position = mousePos;

        // Kiểm tra phím Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tìm tất cả quả cầu đang va chạm với hồng tâm
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                Bubble bubble = collider.GetComponent<Bubble>();
                if (bubble != null)
                {
                    bubble.TryDestroy();
                }
            }
        }
    }
}