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

public class Warning : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] List<GameObject> CollidablesTrigger;
    [SerializeField] GameObject parent;
    [SerializeField] Camera camera;
    [SerializeField] Vector2 camera_coordinates;
    
    Vector2 coordinates;
    [System.Serializable]
    public class Presets
    {
        public string name;
        public List<float> whereToSpawn_x;
    }
    [SerializeField] private List<Presets> presets;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zero"))
        {
            Invoke("Preset_0", 0.1f);
            Debug.Log("Colliding.");
        }
        else if (other.CompareTag("one"))
        {
            Invoke("Preset_1", 0.1f);
            Debug.Log("Colliding.");
        }
        else if (other.CompareTag("two"))
        {
            Invoke("Preset_2", 0.1f);
            Debug.Log("Colliding.");
        }
        else if (other.CompareTag("three"))
        {
            Invoke("Preset_3", 0.1f);
            Debug.Log("Colliding.");
        }
        else if (other.CompareTag("four"))
        {
            Invoke("Preset_4", 0.1f);
            Debug.Log("Colliding.");
        }
        else if (other.CompareTag("five"))
        {
            Invoke("Preset_5", 0.1f);
            Debug.Log("Colliding.");
        }
    }
    async Task Preset_0()
    {
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        for (int i = 0; i < presets[0].whereToSpawn_x.Count; i++)
        {
            
            
            Vector2 coordinates = new Vector2(presets[0].whereToSpawn_x[i], 7 + camera_coordinates.y);
            var assignParent = Instantiate(Prefab, coordinates, Quaternion.identity);
            assignParent.transform.parent = parent.transform;
            
        }
    }
    async Task Preset_1()
    {
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        for (int i = 0; i < presets[1].whereToSpawn_x.Count; i++)
        {
            
            Vector2 coordinates = new Vector2(presets[1].whereToSpawn_x[i], 7 + camera_coordinates.y);
            var assignParent = Instantiate(Prefab, coordinates, Quaternion.identity);
            assignParent.transform.parent = parent.transform;
            
        }
    }
    async Task Preset_2()
    {
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        for (int i = 0; i < presets[2].whereToSpawn_x.Count; i++)
        {
            
            Vector2 coordinates = new Vector2(presets[2].whereToSpawn_x[i], 7 + camera_coordinates.y);
            var assignParent = Instantiate(Prefab, coordinates, Quaternion.identity);
            assignParent.transform.parent = parent.transform;
            
        }
    }
    async Task Preset_3()
    {
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        for (int i = 0; i < presets[3].whereToSpawn_x.Count; i++)
        {
            
            Vector2 coordinates = new Vector2(presets[3].whereToSpawn_x[i], 7 + camera_coordinates.y);
            var assignParent = Instantiate(Prefab, coordinates, Quaternion.identity);
            assignParent.transform.parent = parent.transform;

        }
    }
    async Task Preset_4()
    {
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        for (int i = 0; i < presets[4].whereToSpawn_x.Count; i++)
        {
            
            Vector2 coordinates = new Vector2(presets[4].whereToSpawn_x[i], 7 + camera_coordinates.y);
            var assignParent = Instantiate(Prefab, coordinates, Quaternion.identity);
            assignParent.transform.parent = parent.transform;
            
        }
    }
    async Task Preset_5()
    {
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        for (int i = 0; i < presets[5].whereToSpawn_x.Count; i++)
        {
            
            Vector2 coordinates = new Vector2(presets[5].whereToSpawn_x[i], 7 + camera_coordinates.y);
            var assignParent = Instantiate(Prefab, coordinates, Quaternion.identity);
            assignParent.transform.parent = parent.transform;
            
        }
    }
}
