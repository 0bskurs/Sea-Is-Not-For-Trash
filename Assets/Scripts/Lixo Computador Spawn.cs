using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LixoComputadorSpawn : MonoBehaviour
{
    public List<GameObject> PecaComputadorSpawn;
    // Peças do computador spawnar de acordo com a cena carregada
    
    public int randomIndex;
    public float spawnInterval = 2f; 
    public float spawnDelay = 0f; 
    int total = 0;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public int specificPrefab;
    [SerializeField] private int minimumSpawnDelay, maximumSpawnDelay;
    [SerializeField] private float setSpawnDelay;
    [SerializeField] int randomTimeChosen;
    [SerializeField] private int scene;
    [SerializeField] private int randomTimeMin;
    [SerializeField] private int randomTimeMax;
    [SerializeField] private int setSpawnStart;

    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        randomTimeChosen = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);

        setSpawnStart = UnityEngine.Random.Range(minimumSpawnDelay, maximumSpawnDelay);
        
        InvokeRepeating("SpawnSpecificPrefab",setSpawnStart, 12f);
    }

    async Task SpawnSpecificPrefab()
    {
        randomTimeChosen = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);
        await Task.Delay(100);
        total += 1;

        Debug.Log($"SpawnSpecificPrefab called " + total + " times.");
        if (PecaComputadorSpawn.Count == 0)
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
        


        if (scene == 1)
        {
            
            specificPrefab = scene - 1;
            GameObject chosenPrefab = PecaComputadorSpawn[specificPrefab];
            Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Computer part spawned!");
        }
        
        // instanciar prefab
        

       
    }



}
