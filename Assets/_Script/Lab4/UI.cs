using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject youWinPanel;
    [SerializeField] private TextMeshProUGUI CompletionTimeText;

    public static UI Ins;

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
        youWinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void YouWinPanel()
    {
        if (GameManager.Ins.CountCoin() > 0) return;
        Time.timeScale = 0;
        CompletionTimeText.text = "Completion Time: " + Mathf.FloorToInt(Time.time).ToString("F2") + "s";
        youWinPanel.SetActive(true);
    }
}
