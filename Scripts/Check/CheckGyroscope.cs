using UnityEngine;

public class CheckGyroscope : MonoBehaviour
{
    public GameObject mainCanvas;

    void Awake()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("This device doesn't have gyroscope");
            LoadingScreenManager.LoadScene(4);
            return;
        }

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            LoadingScreenManager.LoadScene(5);
            return;
        }

        mainCanvas.SetActive(true);
    }
}
