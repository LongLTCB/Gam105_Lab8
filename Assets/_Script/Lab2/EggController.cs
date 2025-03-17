using UnityEngine;
public class EggController : MonoBehaviour
{
    [SerializeField] GameObject prefabEggBroken;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name.Equals("Platform"))
        {
            GameObject brokenEggInstance = Instantiate(prefabEggBroken, transform.position, Quaternion.identity);
            Destroy(brokenEggInstance, 3f);
            Destroy(gameObject);
            UIManager.Instance.AddScore(-1);
        }

        if(other.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
            UIManager.Instance.AddScore(5);
        }
    }
}
