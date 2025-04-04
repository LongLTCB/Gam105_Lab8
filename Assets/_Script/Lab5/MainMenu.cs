using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private UIDocument uiDocument;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();

        // Tìm các nút trong Menu Chính
        Button playButton = uiDocument.rootVisualElement.Q<Button>("PlayButton");
        Button levelSelectButton = uiDocument.rootVisualElement.Q<Button>("LevelSelectButton");
        Button quitButton = uiDocument.rootVisualElement.Q<Button>("QuitButton");

        if (playButton != null) playButton.clicked += () => LoadFirstLevel();
        if (levelSelectButton != null) levelSelectButton.clicked += () => ShowLevelSelect();
        if (quitButton != null) quitButton.clicked += () => QuitGame();

        // Tìm các nút trong Select Level Menu
        for (int i = 1; i <= 9; i++)
        {
            int levelIndex = i; // Lưu giá trị để tránh lỗi closure
            Button levelButton = uiDocument.rootVisualElement.Q<Button>($"Level{levelIndex}");
            if (levelButton != null)
            {
                levelButton.clicked += () => LoadLevel(levelIndex);
            }
        }

        // Gán sự kiện cho nút Back (trong Select Level Menu)
        Button backButton = uiDocument.rootVisualElement.Q<Button>("BackButton");
        if (backButton != null)
        {
            backButton.clicked += () => ShowMainMenu();
        }
    }

    void LoadFirstLevel()
    {
        LoadLevel(1); // Chơi từ Level 1
    }

    void LoadLevel(int levelNumber)
    {
        string sceneName = $"Level{levelNumber}";
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene {sceneName} chưa được thêm vào Build Settings!");
        }
    }

    void ShowLevelSelect()
    {
        SceneManager.LoadScene("SelectLevelMenu"); // Hiển thị màn chọn level
    }

    void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Quay về menu chính
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game đã thoát! (Chỉ hoạt động khi Build)");
    }
}
