using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour
{
    public static GPS Instance { get; set; }
    public static float scaleFactor = 10f;
    public static bool gpsFix = false;

    public float initX;
    public float initZ;

    private float m_newPosX;
    private float m_newPosZ;
    private float m_defaultPosY = 1f;
    private int m_updateRateInSeconds = 5 * 60;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        gpsFix = false;

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start(1f, 1f);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }

        //Set Position
        initX = (float)((Input.location.lastData.longitude * 20037508.34 / 180) / 100);
        initZ = (float)(System.Math.Log(System.Math.Tan((90 + Input.location.lastData.latitude) * System.Math.PI / 360)) / (System.Math.PI / 180));
        initZ = (float)((initZ * 20037508.34 / 180) / 100);

        gpsFix = true;

        yield break;
    }

    private void Update()
    {
        if (gpsFix && (Time.frameCount % m_updateRateInSeconds == 0))
        {
            m_newPosX = (float)(((Input.location.lastData.longitude * 20037508.34 / 180) / 100) - initX);
            m_newPosZ = (float)(System.Math.Log(System.Math.Tan((90 + Input.location.lastData.latitude) * System.Math.PI / 360)) / (System.Math.PI / 180));
            m_newPosZ = (float)(((m_newPosZ * 20037508.34 / 180) / 100) - initZ);

            transform.position = new Vector3(m_newPosX * scaleFactor, m_defaultPosY, m_newPosZ * scaleFactor);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 40), "latitude " + transform.position.x);
        GUI.Label(new Rect(10, 40, 200, 40), "longitude " + transform.position.z);
        GUI.Label(new Rect(10, 70, 200, 40), "transform.rotation.x = " + transform.rotation.x);
        GUI.Label(new Rect(10, 100, 200, 40), "transform.rotation.y = " + transform.rotation.y);
        GUI.Label(new Rect(10, 130, 200, 40), "transform.rotation.z = " + transform.rotation.z);
    }
}
