using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == "Game")
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(sceneName);
        }
    }
}
