using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Hráè, kterého kamera sleduje
    public float smoothSpeed = 0.125f; // Plynulost pohybu kamery
    public Vector3 offset; // Offset kamery od hráèe

    void LateUpdate()
    {
        // Vypoèítáme požadovanou pozici kamery s offsetem
        Vector3 desiredPosition = player.position + offset;

        // Plynulý pøechod mezi aktuální a požadovanou pozicí
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Ujistíme se, že kamera se bude pohybovat pouze v ose X a Y (nebo jiných požadovaných osách)
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }


}
