using UnityEngine;

public class ModelGameplay : MonoBehaviour
{
    private Model m_model { get; set; }
    private Vector3 m_defaultLocalScale;
    private bool isTouch = false;

    private void Start()
    {
        m_defaultLocalScale = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
    }

    public void LoadModel(Model item)
    {
        m_model = item;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerRadius")
        {
            transform.localScale = m_defaultLocalScale;
        }
    }

    private void OnMouseDown()
    {
        isTouch = true;
        DestroyObject(this.gameObject);
    }

    private void OnMouseExit()
    {
        isTouch = false;
    }

    private void OnMouseUp()
    {
        isTouch = false;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 200, 200, 40), "isTouch = " + isTouch);
    }
}
