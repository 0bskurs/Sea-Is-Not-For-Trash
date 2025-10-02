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
using System.Linq;
public class PrefabSpawnNew : MonoBehaviour
{
    [System.Serializable]
    public class SpawnLocations
    {
        public string number;
        public Vector2 spawnLocation;
        public GameObject spawnLocationIndicator;
    }

    [System.Serializable]
    public class Presets
    {
        public string preset;
        public List<bool> hasGameObject;
        public List<int> whichGameObject;

    }

    [System.Serializable]
    public class PrefabVariation
    {
        public string objectName;
        public int objectNumber;
        public GameObject prefabVariant;
    }
    public List<Presets> presets_;
    public List<PrefabVariation> prefabVariations;
    public List<SpawnLocations> spawnLocations_;
    [SerializeField] private float timer = 0;
    [SerializeField] private List<int> orderPreset;

    public void Start()
    {
        for (int i = 0; i < presets_[0].hasGameObject.Count; i++)
        {
            if (presets_[0].hasGameObject[i] == true)
            {
                Debug.Log($"{i} " + "IsTrue!");
            }
            else
            {
                Debug.Log($"{i} " + "IsFalse!");
            }
        }
        SpawnLocation();
        Spawn();
    }
    
    public void SpawnLocation()
    {
        for (int i = 0; i < spawnLocations_.Count; i++)
        {
            Instantiate(spawnLocations_[i].spawnLocationIndicator, spawnLocations_[i].spawnLocation, Quaternion.identity);
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;

    }
    public void Spawn()
    {
        
    }
    private async Task SpawnPresets()
    {
        
        for (int i = 0; i < orderPreset.Count; i++)
        {
            for (int j = 0; j < presets_[orderPreset[i]].hasGameObject.Count; j++)
            {
                if (presets_[orderPreset[i]].hasGameObject[j] == true)
                {
                    int y = presets_[orderPreset[i]].whichGameObject[j];
                    Console.WriteLine("Spawned!!");
                    Instantiate(prefabVariations[y].prefabVariant, spawnLocations_[j].spawnLocation, Quaternion.identity);
                }
            }
        }
    }
    // 0 : Garrafa
    // 1 : Ancora 
    // 2 : Radioativo
}




