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
    [SerializeField] GameObject parent;
    [SerializeField] Camera camera;
    [SerializeField] Vector2 camera_coordinates;
    [SerializeField] private float PrefabPositionX;
    public bool WarningOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerMove"))
        {
            Invoke("Preset", 0.1f);
            if (WarningOff == true)
            {
                Destroy(WarningPrefab);
            }
        }
    }

    async Task Preset()
    {
        PrefabPositionX = TrashPrefab.transform.position.x;
        camera_coordinates = camera.transform.position;
        await Task.Delay(100);
        Vector2 coordinates = new Vector2(PrefabPositionX, 7 + camera_coordinates.y);
        var assignParent = Instantiate(WarningPrefab, coordinates, Quaternion.identity);
        assignParent.transform.parent = parent.transform;
    }
    
}
