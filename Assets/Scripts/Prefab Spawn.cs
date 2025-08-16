using System;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
public class PrefabSpawn : MonoBehaviour
{
    
    public GameObject[] prefabsToSpawn; 
    public float spawnInterval = 2f; 
    public float spawnDelay = 0f; 
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", spawnDelay, spawnInterval);
    }
    async Task SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogWarning("No prefabs assigned to Spawner script.");
            return;
        }

        // escolher prefab aleatória
        int randomIndex = UnityEngine.Random.Range(0, prefabsToSpawn.Length);
        GameObject chosenPrefab = prefabsToSpawn[randomIndex];

        // gerar posicao aleatória
        float randomX = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f); // z é 0

        // instanciar prefab
        Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);

       
    }
    
}
