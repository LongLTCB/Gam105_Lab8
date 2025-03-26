using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Coins;

    public static GameManager Ins;

    void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public double CountCoin()
    {
        return Coins.transform.childCount;
    }
}
