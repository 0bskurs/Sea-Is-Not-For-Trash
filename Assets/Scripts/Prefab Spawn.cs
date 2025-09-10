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
    public class WeightedObject
    {
        public GameObject prefabToSpawn;  // The prefab to spawn
        public int weight;                // The weight for the chance of spawning this object
    }

    public List<WeightedObject> spawnOptions;

    // Dictionary for storing spawn weights per scene
    [SerializeField] private Dictionary<string, List<WeightedObject>> sceneSpawnWeights = new Dictionary<string, List<WeightedObject>>();

    // Spawn interval in seconds
    public float spawnInterval = 2.0f;

    // Spawn area (min/max x values)
    public float minX = -8f;
    public float maxX = 8f;

    // Start method to initiate the spawning process
    void Start()
    {
        // Set up the spawn weights for each scene (using default values for now)
        SetSceneWeights();

        // Start the spawn coroutine to spawn objects continuously (temporarily for testing)
        StartCoroutine(SpawnObjectContinuously());
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
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
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
    
    


