using UnityEngine;

public class CheckGPS : MonoBehaviour
{
    public GameObject GPSWarning;

    void Update()
    {
        if (!Input.location.isEnabledByUser)
        {
            GPSWarning.SetActive(true);
        }
        else
        {
            GPSWarning.SetActive(false);
        }
    }
}
