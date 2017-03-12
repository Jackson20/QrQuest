using UnityEngine;

public class AppConfig : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
