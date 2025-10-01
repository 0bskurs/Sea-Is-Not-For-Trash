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

public class PrefabSpawnOld : MonoBehaviour
{
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
                Debug.Log($"{i} "+"IsFalse!");
            }
        }
    }
    // 1 : Garrafa
    // 2 : Radioativo
    // 3
}
    
    


