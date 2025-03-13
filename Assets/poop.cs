using System.Collections;
using UnityEngine;

public class poop : MonoBehaviour
{
    public GameObject poopPrefab; // Prefab hovínka
    public float spawnInterval = 2f; // Jak èasto se spawnují
    public float startX = 0f; // Zaèátek na ose X
    public float moveDistance = 3f; // O kolik se posune doprava

    private float currentX; // Ukládá poslední pozici hovínka

    void Start()
    {
        currentX = startX; // Startovní pozice
        StartCoroutine(SpawnPoop()); // Spustí generování hovínek
    }

    IEnumerator SpawnPoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Poèká nastavený èas

            // Nová pozice - vždy dál doprava
            Vector3 spawnPos = new Vector3(currentX, Random.Range(-2f, 2f), 0);

            // Vytvoøení hovínka
            Instantiate(poopPrefab, spawnPos, Quaternion.identity);

            // Posune spawnovací pozici doprava
            currentX += moveDistance;
        }
    }
}
