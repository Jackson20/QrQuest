using UnityEngine;

public class LoadSceneUtils : MonoBehaviour
{
    public void LoadScene(int num)
    {
        LoadingScreenManager.LoadScene(num);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
