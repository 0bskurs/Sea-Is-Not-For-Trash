using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabSpawnOld : MonoBehaviour
{
    
    [System.Serializable]
    public class SpawnLocations
    {
        public string number;
        public Vector2 spawnLocation;
        public GameObject spawnLocationIndicator;
    }

    [System.Serializable]
    public class PresetsWall
    {
        public string preset;
        public List<bool> hasGameObject;
        public List<int> whichGameObject;

    }
    [System.Serializable]
    public class PresetsOther
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
    public List<PresetsWall> presets_Wall;
    public List<PresetsOther> presets_Other;
    public List<PrefabVariation> prefabVariations;
    public List<SpawnLocations> spawnLocations_;
    [SerializeField] private float timer = 0;
    [SerializeField] private List<int> orderPreset_Wall;
    [SerializeField] private List<int> orderPreset_Other;
    [SerializeField] private float delayBetweenSpawn_Walls;
    [SerializeField] private float delayBetweenSpawn_Other;
    public void Start()
    {
        
        for (int i = 0; i < presets_Wall[0].hasGameObject.Count; i++)
        {
            if (presets_Wall[0].hasGameObject[i] == true)
            {
                Debug.Log($"{i} " + "IsTrue!");
            }
            else
            {
                Debug.Log($"{i} " + "IsFalse!");
            }
        }
        SpawnLocation();

        StartCoroutine(SpawnPresetsWall());
        StartCoroutine(SpawnPresetsOther());
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
    //public void Spawn()
    //{
    //    for (int i = 0; i < orderPreset.Count; i++)
    //    {
    //        for (int j = 0; j < presets_[orderPreset[i]].hasGameObject.Count; j++)
    //        {
    //            if (presets_[orderPreset[i]].hasGameObject[j] == true)
    //            {
    //                int y = presets_[orderPreset[i]].whichGameObject[j];
    //                Console.WriteLine("Spawned!!");
    //                Instantiate(prefabVariations[y].prefabVariant, spawnLocations_[j].spawnLocation, Quaternion.identity);
    //            }
    //        }
    //    }
    //}
    
    private void OnDisable()
    {
        StopCoroutine(SpawnPresetsWall());
        StopCoroutine(SpawnPresetsOther());
    }
    [SerializeField] private bool repeat = true;
    [SerializeField] private bool repeat2 = true;
    private IEnumerator<WaitForSeconds> SpawnPresetsWall()
    {
        bool stopCoroutine = false;
        if (stopCoroutine == false)
        {
            yield return new WaitForSeconds(delayBetweenSpawn_Walls);
            while (repeat == true)
            {
                for (int i = 0; i < orderPreset_Wall.Count; i++)
                {
                    
                    stopCoroutine = true;
                    yield return new WaitForSeconds(delayBetweenSpawn_Walls);
                    for (int j = 0; j < presets_Wall[orderPreset_Wall[i]].hasGameObject.Count; j++)
                    {
                        if (presets_Wall[orderPreset_Wall[i]].hasGameObject[j] == true)
                        {
                            int y = presets_Wall[orderPreset_Wall[i]].whichGameObject[j];
                            Console.WriteLine("Spawned!!");
                            Instantiate(prefabVariations[y].prefabVariant, spawnLocations_[j].spawnLocation, Quaternion.identity);
                        }
                    }

                    if (i == orderPreset_Wall.Count-1)
                    {
                        repeat = false;
                    }
                }
            }
            while (repeat == false)
            {
                for (int i = 0; i < orderPreset_Wall.Count; i++)
                {

                    stopCoroutine = true;
                    yield return new WaitForSeconds(delayBetweenSpawn_Walls);
                    for (int j = 0; j < presets_Wall[orderPreset_Wall[i]].hasGameObject.Count; j++)
                    {
                        if (presets_Wall[orderPreset_Wall[i]].hasGameObject[j] == true)
                        {
                            int y = presets_Wall[orderPreset_Wall[i]].whichGameObject[j];
                            Console.WriteLine("Spawned!!");
                            Instantiate(prefabVariations[y].prefabVariant, spawnLocations_[j].spawnLocation, Quaternion.identity);
                        }
                    }

                    if (i == orderPreset_Wall.Count - 1)
                    {
                        repeat = true;
                    }
                }
            }
            

        }
       


    }
    private IEnumerator<WaitForSeconds> SpawnPresetsOther()
    {
        bool stopCoroutine = false;
        if (stopCoroutine == false)
        {
            yield return new WaitForSeconds(delayBetweenSpawn_Other);
            while (repeat2 == true)
            {
                for (int i = 0; i < orderPreset_Other.Count; i++)
                {
                    stopCoroutine = true;
                    yield return new WaitForSeconds(delayBetweenSpawn_Other);
                    for (int j = 0; j < presets_Other[orderPreset_Other[i]].hasGameObject.Count; j++)
                    {

                        if (presets_Other[orderPreset_Other[i]].hasGameObject[j] == true)
                        {
                            int y = presets_Other[orderPreset_Other[i]].whichGameObject[j];
                            Console.WriteLine("Spawned!!");
                            Instantiate(prefabVariations[y].prefabVariant, spawnLocations_[j].spawnLocation, Quaternion.identity);
                        }

                    }
                    if (i == orderPreset_Other.Count-1)
                    {
                        repeat2 = false;
                    }

                }
            }
            while (repeat2 == false)
            {
                for (int i = 0; i < orderPreset_Other.Count; i++)
                {
                    stopCoroutine = true;
                    yield return new WaitForSeconds(delayBetweenSpawn_Other);
                    for (int j = 0; j < presets_Other[orderPreset_Other[i]].hasGameObject.Count; j++)
                    {

                        if (presets_Other[orderPreset_Other[i]].hasGameObject[j] == true)
                        {
                            int y = presets_Other[orderPreset_Other[i]].whichGameObject[j];
                            Console.WriteLine("Spawned!!");
                            Instantiate(prefabVariations[y].prefabVariant, spawnLocations_[j].spawnLocation, Quaternion.identity);
                        }

                    }
                    if (i == orderPreset_Other.Count-1)
                    {
                        repeat2 = true;
                    }

                }
            }

        }



    }

    // 0 : Garrafa
    // 1 : Ancora 
    // 2 : Radioativo
}




