using System.Collections;
using UnityEngine;

public class SetGPSdata : MonoBehaviour
{
    public float latitude;
    public float longitude;

    private float m_defaultPosY = 0f;

    private IEnumerator Start()
    {
        do {
            yield return null;
        } while (!GPS.gpsFix);

        UpdateGeoLocation();
    }

    private void UpdateGeoLocation()
    {
        Vector3 newPos = transform.position;
        newPos.x = GPS.scaleFactor * (float)(((longitude * 20037508.34) / 18000) - GPS.Instance.initX);
        newPos.z = GPS.scaleFactor * (float)(((Mathf.Log(Mathf.Tan((90 + latitude) * Mathf.PI / 360))
            / (Mathf.PI / 180)) * 1113.19490777778) - GPS.Instance.initZ);
        newPos.y = m_defaultPosY;
        transform.position = newPos;
    }

    public void SetLocation(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
        UpdateGeoLocation();
    }
}
