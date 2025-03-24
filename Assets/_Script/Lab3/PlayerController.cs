using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject win;
    Vector3 firstPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        win.SetActive(false);
        firstPosition = transform.position;
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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(x: moveHorizontal, y: moveVertical, z: 0.0f );
        transform.Translate(translation: movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = firstPosition;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
