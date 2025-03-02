using UnityEngine;
using System.Collections.Generic;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // Pole s možnostmi pozadí
    public Transform spawnPoint; // Místo, kde se spawnují nové èásti
    public float spawnDistance = 10f; // Jak daleko od pøedchozího kusu se spawnuje nový
    public float checkDistance = 15f; // Jak daleko se pozadí pohybuje, než je potøeba další

    private List<GameObject> spawnedBackgrounds = new List<GameObject>(); // Seznam už vygenerovaných èástí

    void Start()
    {
        // Vytvoøíme první dvì èásti pozadí
        SpawnBackground();
        SpawnBackground();
    }

    void Update()
    {
        // Pokud je poslední èást pozadí dostateènì daleko, vygenerujeme novou
        if (spawnedBackgrounds.Count > 0 && spawnedBackgrounds[spawnedBackgrounds.Count - 1].transform.position.x < spawnPoint.position.x + checkDistance)
        {
            SpawnBackground();
        }
    }

    void SpawnBackground()
    {
        // Vyber náhodnì jeden prefab z pole
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        GameObject newBackground = Instantiate(backgroundPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);

        // Pøiøadíme pozadí jako dítì objektu BackgroundManager
        newBackground.transform.SetParent(this.transform);

        // Pokud pozadí nemá Rigidbody, pøidáme ho
        if (newBackground.GetComponent<Rigidbody>() != null)
        {
            Destroy(newBackground.GetComponent<Rigidbody>());
        }

        // Pøesuneme spawnPoint dál doprava pro další èást
        spawnPoint.position += Vector3.right * spawnDistance;

        // Pøidáme novì vytvoøené pozadí do seznamu
        spawnedBackgrounds.Add(newBackground);

        // Pokud je seznam pozadí vìtší než 3 (zbyteèné pozadí mimo kameru), odstraníme staré
        if (spawnedBackgrounds.Count > 3)
        {
            Destroy(spawnedBackgrounds[0]);
            spawnedBackgrounds.RemoveAt(0);
        }
    }
}
