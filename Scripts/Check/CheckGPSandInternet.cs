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
            Debug.Log("Error. Check internet connection!");
            Message.text = InternetMessage;
            WarningScreen.SetActive(true);
        }
        else if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Error. Check GPS connection!");
            Message.text = GPSMessage;
            WarningScreen.SetActive(true);
        }
        else
        {
            WarningScreen.SetActive(false);
        }
    }
}
