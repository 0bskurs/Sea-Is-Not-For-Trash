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
    [SerializeField] private PrefabFall prefabFall;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool isMultiple = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prefabFall.triggerActivated = true;
        }
    }


    //[SerializeField] List<GameObject> Prefabs;
    //[SerializeField] List<GameObject> CollidablesTrigger;
    //[SerializeField] Camera camera;
    //[SerializeField] Vector2 camera_coordinates;
    //Vector2 coordinates;
    //[System.Serializable]
    //public class Presets
    //{
    //    public string name;
    //    public List<float> whereToSpawn_x;
    //    public List<int> whichPrefab;
    //}
    //[SerializeField] private List<Presets> presets;
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("0"))
    //    {
    //        Invoke("Preset_0", 0.1f);
    //        Debug.Log("Colliding.");
    //    }
    //    else if (other.CompareTag("1"))
    //    {
    //        Invoke("Preset_1", 0.1f);
    //        Debug.Log("Colliding.");
    //    }
    //    else if (other.CompareTag("2"))
    //    {
    //        Invoke("Preset_2", 0.1f);
    //        Debug.Log("Colliding.");
    //    }
    //    else if (other.CompareTag("3"))
    //    {
    //        Invoke("Preset_3", 0.1f);
    //        Debug.Log("Colliding.");
    //    }
    //    else if (other.CompareTag("4"))
    //    {
    //        Invoke("Preset_4", 0.1f);
    //        Debug.Log("Colliding.");
    //    }
    //    else if (other.CompareTag("5"))
    //    {
    //        Invoke("Preset_5", 0.1f);
    //        Debug.Log("Colliding.");
    //    }
    //}
    //async Task Preset_0()
    //{
    //    for (int i = 0; i < presets[0].whichPrefab.Count; i++)
    //    {
    //        await Task.Delay(300);
    //        await Task.Delay(100);
    //        camera_coordinates = camera.transform.position;
    //        await Task.Delay(100);
    //        Vector2 coordinates = new Vector2(presets[0].whereToSpawn_x[i] + camera_coordinates.x, camera_coordinates.y + 9);
    //        Instantiate(Prefabs[presets[0].whichPrefab[i]], coordinates , Quaternion.identity);
    //        await Task.Delay(1500);
    //    }
    //}
    //async Task Preset_1()
    //{
    //    for (int i = 0; i < presets[1].whichPrefab.Count; i++)
    //    {
    //        await Task.Delay(300);
    //        await Task.Delay(100);
    //        camera_coordinates = camera.transform.position;
    //        await Task.Delay(100);
    //        Vector2 coordinates = new Vector2(presets[1].whereToSpawn_x[i] + camera_coordinates.x, camera_coordinates.y + 9);
    //        Instantiate(Prefabs[presets[1].whichPrefab[i]], coordinates, Quaternion.identity);
    //        await Task.Delay(800);
    //    }
    //}
    //async Task Preset_2()
    //{
    //    for (int i = 0; i < presets[2].whichPrefab.Count; i++)
    //    {
    //        await Task.Delay(300);
    //        await Task.Delay(100);
    //        camera_coordinates = camera.transform.position;
    //        await Task.Delay(100);
    //        Vector2 coordinates = new Vector2(presets[2].whereToSpawn_x[i], camera_coordinates.y + 9);
    //        Instantiate(Prefabs[presets[2].whichPrefab[i]], coordinates, Quaternion.identity);
    //        await Task.Delay(1800);
    //    }
    //}
    //async Task Preset_3()
    //{
    //    for (int i = 0; i < presets[3].whichPrefab.Count; i++)
    //    {
    //        await Task.Delay(300);
    //        await Task.Delay(100);
    //        camera_coordinates = camera.transform.position;
    //        await Task.Delay(100);
    //        Vector2 coordinates = new Vector2(presets[3].whereToSpawn_x[i] + camera_coordinates.x, camera_coordinates.y + 9);
    //        Instantiate(Prefabs[presets[3].whichPrefab[i]], coordinates, Quaternion.identity);
    //        await Task.Delay(550);
    //    }
    //}
    //async Task Preset_4()
    //{
    //    for (int i = 0; i < presets[4].whichPrefab.Count; i++)
    //    {
    //        await Task.Delay(300);
    //        await Task.Delay(100);
    //        camera_coordinates = camera.transform.position;
    //        await Task.Delay(100);
    //        Vector2 coordinates = new Vector2(presets[4].whereToSpawn_x[i] + camera_coordinates.x, camera_coordinates.y + 9);
    //        Instantiate(Prefabs[presets[4].whichPrefab[i]], coordinates, Quaternion.identity);
    //        await Task.Delay(800);
    //    }
    //}
    //async Task Preset_5()
    //{
    //    for (int i = 0; i < presets[5].whichPrefab.Count; i++)
    //    {
    //        await Task.Delay(300);
    //        await Task.Delay(100);
    //        camera_coordinates = camera.transform.position;
    //        await Task.Delay(100);
    //        Vector2 coordinates = new Vector2(presets[5].whereToSpawn_x[i] + camera_coordinates.x, camera_coordinates.y + 9);
    //        Instantiate(Prefabs[presets[5].whichPrefab[i]], coordinates, Quaternion.identity);
    //        await Task.Delay(300);
    //    }
    //}
}




