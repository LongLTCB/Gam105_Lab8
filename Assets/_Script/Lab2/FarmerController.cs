using UnityEngine;

public class FarmerController : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateAnimator();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb.linearVelocity.y);
        Flip(moveHorizontal);
    }

    private void UpdateAnimator()
    {
        float IsRunning = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", IsRunning);
    }

    private void Flip(float moveHorizontal)
    {
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
