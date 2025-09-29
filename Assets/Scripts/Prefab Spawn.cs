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

public class PrefabSpawnNew : MonoBehaviour
{
    [System.Serializable]
    public class PrefabOrders
    {
        public int callPrefabs;
        
    }
    public List<int> PrefabsOrder;
    // 1 : Garrafa
    // 2 : Radioativo
    // 3
}
    
    


