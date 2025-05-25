using UnityEngine;

public class CustomImageTargetResponse : MonoBehaviour
{
    public GameObject canvasPrefab; // Drag InfoMenu_Prefab here
    private GameObject canvasInstance;
    private bool hasSpawned = false;

    public void OnImageFound()
    {
        // 🟡 Log to confirm this method was triggered
        Debug.Log(" OnImageFound() CALLED");

        if (hasSpawned) return;

        // Spawn as child of the image target
        canvasInstance = Instantiate(canvasPrefab, transform);

        // Place it slightly in front of the image
        canvasInstance.transform.localPosition = new Vector3(0, 0, 0.05f);
        canvasInstance.transform.localRotation = Quaternion.identity;
        canvasInstance.transform.localScale = Vector3.one * 0.01f;

        // 🔧 Assign ARCamera to the canvas after instantiation
        Canvas canvas = canvasInstance.GetComponent<Canvas>();
        if (canvas != null && Camera.main != null)
        {
            canvas.worldCamera = Camera.main;
            Debug.Log("ARCamera assigned to canvas");
        }
        else
        {
            Debug.LogWarning("Could not assign ARCamera to canvas.");
        }

        hasSpawned = true;

        Debug.Log(" InfoMenu spawned!");
    }
}
