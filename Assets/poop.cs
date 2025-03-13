using System.Collections;
using UnityEngine;

public class poop : MonoBehaviour
{
    public GameObject poopPrefab; // Prefab hov�nka
    public float spawnInterval = 2f; // Jak �asto se spawnuj�
    public float startX = 0f; // Za��tek na ose X
    public float moveDistance = 3f; // O kolik se posune doprava

    private float currentX; // Ukl�d� posledn� pozici hov�nka

    void Start()
    {
        currentX = startX; // Startovn� pozice
        StartCoroutine(SpawnPoop()); // Spust� generov�n� hov�nek
    }

    IEnumerator SpawnPoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Po�k� nastaven� �as

            // Nov� pozice - v�dy d�l doprava
            Vector3 spawnPos = new Vector3(currentX, Random.Range(-2f, 2f), 0);

            // Vytvo�en� hov�nka
            Instantiate(poopPrefab, spawnPos, Quaternion.identity);

            // Posune spawnovac� pozici doprava
            currentX += moveDistance;
        }
    }
}
