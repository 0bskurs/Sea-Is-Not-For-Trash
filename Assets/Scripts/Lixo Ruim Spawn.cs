using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class LixoRuimSpawn : MonoBehaviour
{
    public List<GameObject> commonTrashToSpawn;
    // 80% de chance
    public List<GameObject> rareTrashToSpawn;
    // 15% de chance
    public List<GameObject> extremeTrashToSpawn;
    // 5% de chance
    public int randomIndex;
    public float spawnInterval = 2f; 
    public float spawnDelay = 0f; 
    int total = 0;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public int randomNumber;
    [SerializeField] private int randomTimeChosen;
    [SerializeField] private int randomTimeMin;
    [SerializeField] private int randomTimeMax;

    void Start()
    {
        randomTimeChosen = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);

        InvokeRepeating("SpawnRandomPrefab",8f, randomTimeChosen);
    }
    
    async Task SpawnRandomPrefab()
    {
        
        await Task.Delay(500);
        randomTimeChosen = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);
        total += 1;

        Debug.Log($"SpawnRandomPrefab called " + total + " times.");
        if ((rareTrashToSpawn.Count == 0) || (commonTrashToSpawn.Count == 0) || (extremeTrashToSpawn.Count == 0))
        {
            Debug.LogWarning("No prefabs assigned to Spawner script.");
            return;
        }

        // escolher prefab aleatória
        randomIndex = UnityEngine.Random.Range(0, 100);
        
        float randomY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        // gerar posicao aleatória
        float randomX = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f); // z é 0

        if (randomIndex > 40)
        {
            randomNumber = UnityEngine.Random.Range(0, commonTrashToSpawn.Count);
            GameObject chosenPrefab = commonTrashToSpawn[randomNumber];
            Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Common rarity trash spawned");
        }
        else if ((randomIndex < 41) && (randomIndex > 10))
        {
            randomNumber = UnityEngine.Random.Range(0, rareTrashToSpawn.Count);
            GameObject chosenPrefab = rareTrashToSpawn[randomNumber];
            Debug.Log("Rare rarity trash spawned");
            Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
        }
        else if (randomIndex < 11)
        {
            randomNumber = UnityEngine.Random.Range(0, extremeTrashToSpawn.Count);
            GameObject chosenPrefab = extremeTrashToSpawn[randomNumber];
            Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Extreme rarity trash spawned");
        }
        // instanciar prefab
        

       
    }
// Separator


}
