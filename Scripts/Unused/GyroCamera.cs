using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    private bool m_isGyroAvailable; //TODO remove this and add message on start
    private Gyroscope m_gyro;
    private float m_calibrationYAngle = 0f;

    private void Start()
    {
        Application.targetFrameRate = 60;

        m_isGyroAvailable = SystemInfo.supportsGyroscope; //TODO remove this and add message
        if (!m_isGyroAvailable)
        {
            return;
        }

        m_gyro = Input.gyro;
        m_gyro.enabled = true;

        m_calibrationYAngle = -transform.eulerAngles.y;
    }

    private void Update()
    {
        if (!m_isGyroAvailable) //TODO remove this and add message on start
            return;

        transform.rotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * m_gyro.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self);
        transform.Rotate(0f, 180f, 0f, Space.World);
        transform.Rotate(0f, -m_calibrationYAngle, 0f, Space.World);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 40), m_gyro.attitude.ToString()); //TODO remove this
    }
}


// Android
//transform.rotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * m_gyro.attitude;
//transform.Rotate(0f, 0f, 180f, Space.Self);
//transform.Rotate(0f, 180f, 0f, Space.World);

//ransform.Rotate( 270f, 180f, 180f, Space.World );


//IOS
//transform.rotation = m_gyro.attitude;
//transform.Rotate(0f, 0f, 180f, Space.Self);
//transform.Rotate(90f, 180f, 0f, Space.World);

//if (Application.platform == RuntimePlatform.Android)
//{
//    m_attitudeFix = new Quaternion(0, 0, -0.5f, 0);
//}
//else if (Application.platform == RuntimePlatform.IPhonePlayer)
//{
//    m_attitudeFix = new Quaternion(1, 1, 1, 1);
//}