using UnityEngine;

public class RotaingItem : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 360));
    }
}
