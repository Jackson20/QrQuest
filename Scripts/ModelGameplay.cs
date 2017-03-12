using UnityEngine;

public class ModelGameplay : MonoBehaviour
{
    private Model m_model { get; set; }

    void Start()
    {

    }

    public void LoadModel(Model item)
    {
        m_model = item;
    }
}
