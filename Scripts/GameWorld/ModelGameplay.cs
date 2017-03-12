using UnityEngine;

public class ModelGameplay : MonoBehaviour
{
    private Model m_model { get; set; }
    private Vector3 m_defaultLocalScale;

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
        if (other.name == "Player")
        {
            transform.localScale = m_defaultLocalScale;
        }
    }
}
