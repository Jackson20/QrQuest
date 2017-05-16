using UnityEngine;

public class CheckGyroscope : MonoBehaviour
{
    public GameObject mainCanvas;

    void Awake()
    {
        //if (!SystemInfo.supportsGyroscope)
        //{
        //    Debug.Log("This device doesn't have gyroscope");
        //    LoadingScreenManager.LoadScene(4);
        //    return;
        //}

        mainCanvas.SetActive(true);
    }
}
