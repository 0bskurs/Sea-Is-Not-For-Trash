using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LixoComputadorSpawn : MonoBehaviour
{
    [SerializeField] GameObject prefab_1;
    [SerializeField] Camera _camera;
    [SerializeField] Vector2 positionCamera;
    [SerializeField] float y_position_variance;
    [SerializeField] float timeDelay;
    [SerializeField] Vector2 positionPrefabSpawn;
    [SerializeField] GameObject parent;
    [SerializeField] bool startSpawning = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("SpawnComputador", 0.1f);
        }
    }
    private void Start()
    {
        
        y_position_variance = 9;
        
    }
    
    async Task SpawnComputador()
    {
        await Task.Delay(300);
        positionCamera = _camera.transform.position;
        await Task.Delay(100);
        positionPrefabSpawn = new Vector2(0, positionCamera.y + y_position_variance);
        await Task.Delay(100);
        var parentAssign = Instantiate(prefab_1, positionPrefabSpawn, Quaternion.identity);
        parentAssign.transform.parent = parent.transform;


    }





}
