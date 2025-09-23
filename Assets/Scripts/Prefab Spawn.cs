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
    [SerializeField] private List<int> amountSpawned;
    [SerializeField] private float currentAmountSpawned;
    [SerializeField] private int variableSpawnTime = 1;
    public int countTaskStages;
    [System.Serializable]
    public class WeightedObject
    {
        public GameObject prefabToSpawn;  // The prefab to spawn
        public int weight;                // The weight for the chance of spawning this object
    }
    [System.Serializable]
    public class Stages
    {
        
        public string name; // Stage Name
        public bool _tasks; // True or False verifier for next task on Class
        public float stageStartTime; // Time when the stage starts
        public float minusSpawnTime; // Time cooldown decrease for spawning prefabs
    }
    public List<Stages> stages;
    public List<WeightedObject> spawnOptions;
    
    // Dictionary for storing spawn weights per scene
    [SerializeField] private Dictionary<string, List<WeightedObject>> sceneSpawnWeights = new Dictionary<string, List<WeightedObject>>();

    // Spawn interval in seconds
    public float spawnInterval;
    [SerializeField] private float startAmountSpawned;
    // Spawn area (min/max x values)
    public float minX = -8f;
    public float maxX = 8f;
    public float timer;
    public float spawnStart;
    [SerializeField] private float timeUntilSpawn;
    // Start method to initiate the spawning process
    void Start()
    {
        currentAmountSpawned = startAmountSpawned;
        spawnInterval = spawnStart;
        InvokeRepeating("StageTimer", 5, 0.2f);
        // Set up the spawn weights for each scene (using default values for now)
        SetSceneWeights();
        
        StartCoroutine(SpawnObjectContinuously());
        StartCoroutine(VariableTimeRepeat());
    }
    [SerializeField] private float _duration = 1f;

    [Header("True or False for Stages")][SerializeField] private List<bool> _tasks;
    private void Update()
    {
        timer += Time.deltaTime;

    }
    private IEnumerator<WaitForSeconds> VariableTimeRepeat()
    {
        while (true)
        {
            timeUntilSpawn = (spawnInterval/ (currentAmountSpawned));
            yield return new WaitForSeconds(5f);

        }
    }
    [SerializeField] private int y = 1;
    async Task StageTimer()
    {
        
        while (y < stages.Count)
        {
            await Task.Delay(500);
            if (stages[y].stageStartTime < timer && stages[y - 1]._tasks == true)
            {
                currentAmountSpawned += amountSpawned[y];
                spawnInterval -= stages[y].minusSpawnTime;
                stages[y - 1]._tasks = false;
                stages[y]._tasks = true;
                y++;
            }
        }

        //if (stages[1].stageStartTime < timer && stages[0]._tasks == true)
        //{
        //    spawnInterval -= stages[1].minusSpawnTime;
        //    stages[0]._tasks = false;
        //    stages[1]._tasks = true;

        //}
        //else if (stages[2].stageStartTime < timer && stages[1]._tasks == true)
        //{
        //    spawnInterval -= stages[2].minusSpawnTime;
        //    stages[1]._tasks = false;
        //    stages[2]._tasks = true;
        //}
        //else if (stages[3].stageStartTime < timer && stages[2]._tasks == true)
        //{
        //    spawnInterval -= stages[3].minusSpawnTime;
        //    stages[2]._tasks = false;
        //    stages[3]._tasks = true;
        //    currentAmountSpawned = amountSpawned[1];
        //}
        //else if (stages[4].stageStartTime < timer && stages[3]._tasks == true)
        //{
        //    spawnInterval -= stages[4].minusSpawnTime;
        //    stages[3]._tasks = false;
        //    stages[4]._tasks = true;
            
        //}
        //else if (stages[5].stageStartTime < timer && stages[4]._tasks == true)
        //{
        //    spawnInterval -= stages[5].minusSpawnTime;
        //    stages[4]._tasks = false;
        //    stages[5]._tasks = true;
        //    currentAmountSpawned = amountSpawned[2];
        //}



    }
    // Set the weights for each scene, this can be expanded for more scenes
    void SetSceneWeights()
    {
        // Can add more scenes later
        sceneSpawnWeights["FirstLevel"] = spawnOptions;
        sceneSpawnWeights["SecondLevel"] = spawnOptions;
        sceneSpawnWeights["ThirdLevel"] = spawnOptions;
        sceneSpawnWeights["FourthLevel"] = spawnOptions;
    }

    // Coroutine to spawn objects continuously at a fixed interval (temporary)
    private IEnumerator<WaitForSeconds> SpawnObjectContinuously()
    {
        while (true)
        {
            for (int i = 0; i < currentAmountSpawned; i++)
            {
                SpawnObject();
                yield return new WaitForSeconds(timeUntilSpawn);
            }
            
        }
    }

    // Spawn an object based on weighted chances for the current scene
    public void SpawnObject()
    {
        // Get the current scene name
        string currentScene = SceneManager.GetActiveScene().name;

        // If no weights are found for the current scene, return early
        if (!sceneSpawnWeights.ContainsKey(currentScene))
        {
            Debug.LogWarning("No spawn weights set for this scene.");
            return;
        }

        // Get the list of WeightedObjects for the current scene
        List<WeightedObject> currentSceneWeights = sceneSpawnWeights[currentScene];

        // Calculate the total weight
        int totalWeight = 0;
        foreach (var weightedObject in currentSceneWeights)
        {
            totalWeight += weightedObject.weight;
        }

        // If the total weight is 0, don't spawn anything
        if (totalWeight == 0)
        {
            Debug.Log("No objects available to spawn in this scene.");
            return;
        }

        // Pick a random value between 0 and the total weight
        int randomValue = UnityEngine.Random.Range(0, totalWeight);

        // Select the object based on the random value and weighted chances
        int cumulativeWeight = 0;
        foreach (var weightedObject in currentSceneWeights)
        {
            cumulativeWeight += weightedObject.weight;

            if (randomValue < cumulativeWeight)
            {
                // Get a random X coordinate within the scene bounds
                float randomX = UnityEngine.Random.Range(minX, maxX);

                // Spawn the selected object at a random X position
                Instantiate(weightedObject.prefabToSpawn, new Vector2(randomX, 9), Quaternion.identity);
                break;
            }
        }
    }

    

}
    
    


