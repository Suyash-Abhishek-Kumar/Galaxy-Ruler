using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private int maxLevel = 8;

    void Awake()
    {
        // Make this persist between scenes (optional)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void LoadLevelMap()
    {
        SceneManager.LoadScene("LevelMapScene");
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void LoadGameWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoadLevelByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void One() { SceneLoader.Instance.LoadLevel(1); }
    public void Two() { SceneLoader.Instance.LoadLevel(2); }
    public void Three() { SceneLoader.Instance.LoadLevel(3); }
    public void Four() { SceneLoader.Instance.LoadLevel(4); }
    public void Five() { SceneLoader.Instance.LoadLevel(5); }
    public void Six() { SceneLoader.Instance.LoadLevel(6); }
    public void Seven() { SceneLoader.Instance.LoadLevel(7); }
    public void Eight() { SceneLoader.Instance.LoadLevel(8); }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void LoadLevel(int level)
    {
        LevelManager.Instance.SetLevel(level);
        SceneLoader.Instance.LoadGameplay();
    }

    public void Retry()
    {
        int thisLevel = LevelManager.Instance.currentLevel;
        SceneLoader.Instance.LoadLevel(thisLevel);
    }

    public void LoadNextLevel()
    {
        int nextLevel = LevelManager.Instance.currentLevel + 1;

        // Optional: Add max level check
        if (nextLevel > maxLevel)
        {
            Debug.Log("All levels completed!");
            SceneLoader.Instance.LoadHome(); // or Main Menu
            return;
        }
        SceneLoader.Instance.LoadLevel(nextLevel); // replace with your actual Gameplay Scene name

    }

}
