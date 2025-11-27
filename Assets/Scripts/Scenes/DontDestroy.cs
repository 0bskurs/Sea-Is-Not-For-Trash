using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DontDestroy : MonoBehaviour
{
    public float volume;
    public bool pular_cena;
    public bool hasStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
         DontDestroyOnLoad(this.gameObject);
    }
}
