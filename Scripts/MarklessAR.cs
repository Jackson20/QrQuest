using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour
{
    // Gyro
    private Gyroscope m_gyro;
    private GameObject m_cameraContainer;
    private Quaternion m_rotaion;
    private float m_calibrationYAngle;

    // Cam
    private WebCamTexture m_cam;
    public RawImage background;
    public AspectRatioFitter fit;

    private bool m_arReady = false;

    private void Start()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("This device doesn't have gyroscope");
            return;
        }

        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (!WebCamTexture.devices[i].isFrontFacing)
            {
                m_cam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if (m_cam == null)
        {
            Debug.Log("This device doesn't have back camera");
            return;
        }

        m_cameraContainer = new GameObject("Camera Container");
        m_cameraContainer.transform.position = transform.position;
        transform.SetParent(m_cameraContainer.transform);

        m_gyro = Input.gyro;
        m_gyro.enabled = true;
        m_calibrationYAngle = -transform.eulerAngles.y;
        m_cameraContainer.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        m_rotaion = new Quaternion(0, 0, 1, 0);

        m_cam.Play();
        background.texture = m_cam;

        m_arReady = true;
    }

    private void Update()
    {
        if(m_arReady)
        {
            //Update camera
            float ratio = (float)m_cam.width / (float)m_cam.height;
            fit.aspectRatio = ratio;

            float scaleY = m_cam.videoVerticallyMirrored ? -1.0f : 1.0f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -m_cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

            // Update gyro
            transform.localRotation = m_gyro.attitude * m_rotaion;
            transform.Rotate(0f, -m_calibrationYAngle, 0f, Space.World);
        }
    }
}
