using UnityEngine;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour
{
    private bool m_isCameraAvailable;
    private WebCamTexture m_backCamera;
    private Texture m_defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    private void Start()
    {
        m_defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        //if (devices.Length == 0)
        //{
        //    Debug.Log("No camera detected");
        //    m_isCameraAvailable = false;
        //    return;
        //}

        //for (int i = 0; i < devices.Length; ++i)
        //{
        //    if (!devices[i].isFrontFacing)
        //    {
                m_backCamera = new WebCamTexture(devices[0].name, Screen.width, Screen.height);
        //    }
        //}

        //if (m_backCamera = null)
        //{
        //    Debug.Log("Unable to find back camera");
        //    return;
        //}

        Application.targetFrameRate = 60;

        m_backCamera.Play();
        background.texture = m_backCamera;
        m_isCameraAvailable = true;
    }

    private void Update()
    {
        if (!m_isCameraAvailable)
            return;

        float ratio = (float)m_backCamera.width / (float)m_backCamera.height;
        fit.aspectRatio = ratio;

        float scaleY = m_backCamera.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -m_backCamera.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
