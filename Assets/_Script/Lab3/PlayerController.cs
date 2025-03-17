using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(x: moveHorizontal, y: moveVertical, z: 0.0f );
        transform.Translate(translation: movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 firstPosition = new Vector2(x: -7.5f, y: 3f);
            transform.position = firstPosition;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Win");
        }
    }

}
