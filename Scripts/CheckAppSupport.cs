using UnityEngine;

public class CheckAppSupport : MonoBehaviour
{
    void Awake()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            LoadingScreenManager.LoadScene(4);
            Debug.Log("This device doesn't have gyroscope");
            return;
        }

        if (!Input.location.isEnabledByUser)
        {

        }
    }
}
