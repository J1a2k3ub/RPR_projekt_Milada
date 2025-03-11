using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Hr��, kter�ho kamera sleduje
    public float smoothSpeed = 0.125f; // Plynulost pohybu kamery
    public Vector3 offset; // Offset kamery od hr��e

    void LateUpdate()
    {
        // Vypo��t�me po�adovanou pozici kamery s offsetem
        Vector3 desiredPosition = player.position + offset;

        // Plynul� p�echod mezi aktu�ln� a po�adovanou pozic�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Ujist�me se, �e kamera se bude pohybovat pouze v ose X a Y (nebo jin�ch po�adovan�ch os�ch)
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }


}
