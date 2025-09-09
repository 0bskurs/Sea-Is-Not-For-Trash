using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabSpawn : MonoBehaviour
{
    

    // Scene 1 : Level 1
    // Scene 4 : Level 2
    // Scene 5 : Level 3
    // Scene 6 : Level 4
    
    [System.Serializable]
    public class Bottle
    {
        public GameObject prefab;
        public int specificScene;
        public int chancePoint;
    }
    [System.Serializable]
    public class RadioactiveWaste
    {
        public GameObject prefab;
        public int specificScene;
        public int chancePoint;
    }
    [System.Serializable]
    public class Anchor
    {
        public GameObject prefab;
        public int specificScene;
        public int chancePoint;
    }
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    [SerializeField] public Anchor[] anchors;
    [SerializeField] public Bottle[] bottles;
    [SerializeField] public RadioactiveWaste[] radioactiveWastes;
    

    private void Awake()
    {
        
       
    }
    
    public int randomIndex;
    public int scene;
    public float spawnInterval = 2f; 
    public float spawnDelay = 0f; 
    int total = 0;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public int randomNumber;
    int randomTimeChosen;
    [SerializeField] private int randomTimeMin;
    [SerializeField] private int randomTimeMax;
    public int totalChance;
    public int sceneToPrefab;
    [SerializeField] private int chance_1st;
    [SerializeField] private int chance_2nd;
    [SerializeField] private int chance_3rd;
    [SerializeField] int x, y, z;
    [SerializeField] GameObject a, b, c;
    public void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        randomTimeChosen = UnityEngine.Random.Range(randomTimeMin, randomTimeMax);
        InvokeRepeating("SpawnRandomPrefab",8f, 6f);
        Invoke("StartScript", 0.2f);
        Invoke("Orderer",0.3f);

        
        
    }
    async Task StartScript()
    {
        await Task.Delay(100);
        if (scene == 1)
        {
            sceneToPrefab = 0;
        }
        else if (scene == 4)
        {
            sceneToPrefab = 1;
        }
        else if (scene == 5)
        {
            sceneToPrefab = 2;
        }
        else if (scene == 6)
        {
            sceneToPrefab = 3;
        }
        else
        {
            Debug.LogWarning("No scene matched for prefab spawning.");
        }

        x = anchors[sceneToPrefab].chancePoint;
        y = radioactiveWastes[sceneToPrefab].chancePoint;
        z = bottles[sceneToPrefab].chancePoint;

        a = anchors[sceneToPrefab].prefab;
        b = radioactiveWastes[sceneToPrefab].prefab;
        c = bottles[sceneToPrefab].prefab;
        if (x == 0)
        {
            chance_3rd = 0;
            Debug.Log("Anchor prefab chance point is 0.");
        }


        if (y == 0)
        {
            chance_3rd = 0;
            Debug.Log("Radioactive Waste prefab chance point is 0.");
        }
        if (z == 0)
        {
            chance_3rd = 0;
            Debug.Log("Bottle prefab chance point is 0.");
        }
    }
    async Task Orderer()
    {
        await Task.Delay(300);
        if ((x > y) && (y > z))
        {
            chance_1st = x;
            prefab1 = a;

            chance_2nd = y;
            prefab2 = b;

            chance_3rd = z;
            prefab3 = c;

        }
        else if ((x > z) && (z > y))
        {
            chance_1st = x;
            prefab1 = a;
            chance_2nd = z;
            prefab2 = c;
            chance_3rd = y;
            prefab3 = b;
            Debug.Log("Chances (from highest to lowest): " + prefab1 + ", " + prefab2 + ", " + prefab3);
        }
        else if ((y > x) && (x > z))
        {
            chance_1st = y;
            prefab1 = b;
            chance_2nd = x;
            prefab2 = a;
            chance_3rd = z;
            prefab3 = c;
            Debug.Log("Chances (from highest to lowest): " + prefab1 + ", " + prefab2 + ", " + prefab3);
        }
        else if ((y > z) && (z > x))
        {
            chance_1st = y;
            prefab1 = b;
            chance_2nd = z;
            prefab2 = c;
            chance_3rd = x;
            prefab3 = a;
            Debug.Log("Chances (from highest to lowest): " + prefab1 + ", " + prefab2 + ", " + prefab3);
        }
        else if ((z > x) && (x > y))
        {
            chance_1st = z;
            prefab1 = c;
            chance_2nd = x;
            prefab2 = a;
            chance_3rd = y;
            prefab3 = b;
        }
        else if ((z > y) && (y > x))
        {
            chance_1st = z;
            prefab1 = c;
            chance_2nd = y;
            prefab2 = c;
            chance_3rd = x;
            prefab3 = a;
        }
    }

    async Task SpawnRandomPrefab()
    {
        await Task.Delay(0);
        total += 1;

        Debug.Log($"SpawnRandomPrefab called " + total + " times.");
        

        // escolher prefab aleatória
        randomIndex = UnityEngine.Random.Range(1, 100);
        
        float randomY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        // gerar posicao aleatória
        float randomX = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f); // z é 0
        
        if (chance_3rd != 0)
        {
            if (randomIndex > chance_1st)
            {
                
                GameObject chosenPrefab = prefab1;
                Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
                Debug.Log("Common rarity trash spawned");
            }
            else if ((randomIndex <= chance_1st) && (randomIndex > chance_2nd))
            {
                
                GameObject chosenPrefab = prefab2;
                Debug.Log("Rare rarity trash spawned");
                Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
            }
            else if (randomIndex <= chance_2nd)
            {
                
                GameObject chosenPrefab = prefab3;
                Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
                Debug.Log("Extreme rarity trash spawned");
            }
        }
        else if (chance_3rd == 0) 
        {
            if (randomIndex > chance_1st)
            {

                GameObject chosenPrefab = prefab1;
                Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
                Debug.Log("Common rarity trash spawned");
            }
            else if (randomIndex <= chance_1st)
            {

                GameObject chosenPrefab = prefab2;
                Debug.Log("Rare rarity trash spawned");
                Instantiate(chosenPrefab, spawnPosition, Quaternion.identity);
            }


        }
        
        

        // instanciar prefab

    }
    
    
}

