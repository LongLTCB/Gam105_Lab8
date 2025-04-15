using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    public UIDocument uiDocument; // UI Document
    public Info info;

    private Label levelLabel;
    private Label deathCountLabel;
    private Button menuButton;


    private int deathCount;

    void Start()
    {
        // Lấy RootVisualElement từ UI Document
        var root = uiDocument.rootVisualElement;

        PlayerPrefs.DeleteKey("DeathCount");
        info.deathCount = 0;

        // Tìm các UI Elements
        levelLabel = root.Q<Label>("LevelLabel");
        deathCountLabel = root.Q<Label>("DeathCountLabel");
        menuButton = root.Q<Button>("MenuButton");

        // Cập nhật số màn chơi
       info.numberLevel = SceneManager.GetActiveScene().buildIndex;
        levelLabel.text = info.numberLevel + " / 5";

        // Load số lần chết từ PlayerPrefs
        info.deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        UpdateDeathCountUI();

        // Thêm sự kiện cho nút menu
        menuButton.clicked += GoToMainMenu;
    }

    public void IncreaseDeathCount()
    {
        info.deathCount++;
        PlayerPrefs.SetInt("DeathCount", info.deathCount); // Lưu số lần chết
        UpdateDeathCountUI();
    }

    void UpdateDeathCountUI()
    {
        deathCountLabel.text = "Deaths: " + info.deathCount;
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
