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
using Unity.VisualScripting;

public class Warning : MonoBehaviour
{
    [SerializeField] GameObject TrashPrefab;
    [SerializeField] GameObject WarningPrefab;
    public Transform transformParent;
    [SerializeField] Camera camera;
    [SerializeField] Vector2 camera_coordinates;
    [SerializeField] private float PrefabPositionX;
    [SerializeField] bool stopTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerMove") && stopTrigger == false)
        {
            Invoke("Preset", 0f);
            stopTrigger = true;
        }
    }

    async Task Preset()
    {
        PrefabPositionX = TrashPrefab.transform.position.x;
        camera_coordinates = camera.transform.position;
        Vector2 coordinates = new Vector2(PrefabPositionX, 7 + camera_coordinates.y);
        var assignParent = Instantiate(WarningPrefab, coordinates, Quaternion.identity);
        assignParent.transform.SetParent(transformParent);
    }
    
    
}
