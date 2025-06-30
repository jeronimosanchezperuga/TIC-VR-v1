using UnityEngine;

public class FloatingCanvasFollower : MonoBehaviour
{
    public Transform playerHead; // Asigná el XR Origin > Main Camera
    public float followDistance = 1.5f;
    public float heightOffset = 0.0f;
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (playerHead == null) return;

        Vector3 targetPosition = playerHead.position + playerHead.forward * followDistance;
        targetPosition.y = playerHead.position.y + heightOffset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

        // Hacer que mire al jugador
        transform.LookAt(playerHead);
        transform.Rotate(0, 180f, 0); // Porque por defecto el canvas está "de espaldas"
    }
}
