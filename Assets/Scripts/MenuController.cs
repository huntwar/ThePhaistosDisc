using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject infoCanvas;

    // Call this to hide the menu
    public void HideMenu()
    {
        infoCanvas.SetActive(false);
    }

    // Optional: if you want different behavior for grabbing the cube
    public void GrabCube()
    {
        infoCanvas.SetActive(false);
        // Add other logic here (like enabling a cube or animation)
        Debug.Log("Grabbed the cube!");
    }
}
