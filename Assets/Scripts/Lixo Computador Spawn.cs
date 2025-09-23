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
    [SerializeField] int randomTimeChosen;
    [SerializeField] private int scene;
    [SerializeField] private int randomTimeMin;
    [SerializeField] private int randomTimeMax;
    [SerializeField] private int setSpawnStart;
    [SerializeField] private float index = 0;
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if (scene <= 1)
        {
            specificPrefab = 0;
        }
        else if (scene >= 4 && scene < 5)
        {
            specificPrefab = 1;
        }
        else if (scene >= 5 && scene < 6)
        {
            specificPrefab = 2;
        }
        else if (scene >= 6 && scene < 7)
        {
            specificPrefab = 3;
        }

        setSpawnStart = UnityEngine.Random.Range(minimumSpawnDelay, maximumSpawnDelay);
        StartCoroutine(RandomTimeChoser());
        InvokeRepeating("SpawnSpecificPrefab",setSpawnStart, randomTimeChosen);
    }
    
    private IEnumerator<WaitForSeconds> RandomTimeChoser()
    {
        while (true)
        {
            randomTimeChosen = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);
            yield return new WaitForSeconds(10f);


        }
    }
    async Task SpawnSpecificPrefab()
    {
        // Scene 1 : Level 1
        // Scene 4 : Level 2
        // Scene 5 : Level 3
        // Scene 6 : Level 4
        await Task.Delay(200);
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
        GameObject chosenPrefab = PecaComputadorSpawn[specificPrefab];
        
        
        
        Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Computer part spawned!");

        
        
        // instanciar prefab
        

       
    }



}
