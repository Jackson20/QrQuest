using UnityEngine;
using UnityEngine.UI;

public class CheckGPSandInternet : MonoBehaviour
{
    public GameObject WarningScreen;
    public Text Message;
    public string InternetMessage;
    public string GPSMessage;

    void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Message.text = InternetMessage;
            WarningScreen.SetActive(true);
        }
        else if (!Input.location.isEnabledByUser)
        {
            Message.text = GPSMessage;
            WarningScreen.SetActive(true);
        }
        else
        {
            WarningScreen.SetActive(false);
        }
    }
}
