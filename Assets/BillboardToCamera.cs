using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    public Transform targetCamera; // Asigná aquí la cámara VR (Main Camera del XR Origin)

    void LateUpdate()
    {
        if (targetCamera == null) return;

        // Hace que el objeto mire a la cámara
        transform.LookAt(targetCamera);

        // Invertimos la rotación en Y para que el texto no se vea al revés
        transform.Rotate(0, 180f, 0);
    }
}
