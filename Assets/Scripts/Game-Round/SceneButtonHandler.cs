using UnityEngine;

public class SceneButtonHandler : MonoBehaviour
{
    public void LoadHome() => SceneLoader.Instance.LoadHome();
    public void LoadLevelMap() => SceneLoader.Instance.LoadLevelMap();
    public void LoadGameplay() => SceneLoader.Instance.LoadGameplay();
    public void LoadGameOver() => SceneLoader.Instance.LoadGameOver();
    public void LoadGameWin() => SceneLoader.Instance.LoadGameWin();
    public void QuitGame() => SceneLoader.Instance.QuitGame();
    public void LoadNextLevel() => SceneLoader.Instance.LoadNextLevel();
    public void One() => SceneLoader.Instance.One();
    public void Two() => SceneLoader.Instance.Two();
    public void Three() => SceneLoader.Instance.Three();
    public void Four() => SceneLoader.Instance.Four();
    public void Five() => SceneLoader.Instance.Five();
    public void Six() => SceneLoader.Instance.Six();
    public void Seven() => SceneLoader.Instance.Seven();
    public void Eight() => SceneLoader.Instance.Eight();
    public void Retry() => SceneLoader.Instance.Retry();
    public void RetryCurrentLevel()
    {
        int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        SceneLoader.Instance.LoadLevelByIndex(index);
    }
}
