using UnityEngine;
using System.Collections.Generic;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] backgroundPrefabs; // Pole s mo�nostmi pozad�
    public Transform spawnPoint; // M�sto, kde se spawnuj� nov� ��sti
    public float spawnDistance = 10f; // Jak daleko od p�edchoz�ho kusu se spawnuje nov�
    public float checkDistance = 15f; // Jak daleko se pozad� pohybuje, ne� je pot�eba dal��

    private List<GameObject> spawnedBackgrounds = new List<GameObject>(); // Seznam u� vygenerovan�ch ��st�

    void Start()
    {
        // Vytvo��me prvn� dv� ��sti pozad�
        SpawnBackground();
        SpawnBackground();
    }

    void Update()
    {
        // Pokud je posledn� ��st pozad� dostate�n� daleko, vygenerujeme novou
        if (spawnedBackgrounds.Count > 0 && spawnedBackgrounds[spawnedBackgrounds.Count - 1].transform.position.x < spawnPoint.position.x + checkDistance)
        {
            SpawnBackground();
        }
    }

    void SpawnBackground()
    {
        // Vyber n�hodn� jeden prefab z pole
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        GameObject newBackground = Instantiate(backgroundPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);

        // P�i�ad�me pozad� jako d�t� objektu BackgroundManager
        newBackground.transform.SetParent(this.transform);

        // Pokud pozad� nem� Rigidbody, p�id�me ho
        if (newBackground.GetComponent<Rigidbody>() != null)
        {
            Destroy(newBackground.GetComponent<Rigidbody>());
        }

        // P�esuneme spawnPoint d�l doprava pro dal�� ��st
        spawnPoint.position += Vector3.right * spawnDistance;

        // P�id�me nov� vytvo�en� pozad� do seznamu
        spawnedBackgrounds.Add(newBackground);

        // Pokud je seznam pozad� v�t�� ne� 3 (zbyte�n� pozad� mimo kameru), odstran�me star�
        if (spawnedBackgrounds.Count > 3)
        {
            Destroy(spawnedBackgrounds[0]);
            spawnedBackgrounds.RemoveAt(0);
        }
    }
}
