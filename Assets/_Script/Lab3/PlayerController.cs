using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private float speed;
    [SerializeField] private Vector3 CheckPoint;

    Animator ani;
    bool isRespawning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (isRespawning) return;
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(xDir, yDir);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(Respawn());
        }

        if (other.CompareTag("TargetPoint"))
        {
            StartCoroutine(TargetPoint());
        }

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CheckPoint"))
        {
            CheckPoint = other.transform.position;
        }
    }

    
    IEnumerator Respawn()
    {
        ani.CrossFade("Fade", 0);
        isRespawning = true;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1.5f);

        this.transform.position = CheckPoint;
        yield return new WaitForSeconds(0.1f);

        ani.CrossFade("Player_Idle", 0);
        isRespawning = false;
        GetComponent<Collider2D>().enabled = true;
    }

    IEnumerator TargetPoint()
    {
        yield return new WaitForSeconds(2f);
        UI.Ins.YouWinPanel();
    }
}
