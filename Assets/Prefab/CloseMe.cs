using UnityEngine;

public class CloseMe : MonoBehaviour
{
    public void CloseThis()
    {
        gameObject.SetActive(false);
    }
}
