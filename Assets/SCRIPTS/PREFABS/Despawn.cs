using UnityEngine;

public class Despawn : MonoBehaviour
{
    //cordenada Y para condicao
    [SerializeField] private float DestroyTimer;
    [SerializeField] private float setTimer;
    [SerializeField] GameObject gameObject;
    public bool startDespawnCounter = false;
    [SerializeField] private bool thisObjectWarning;
    void Update()
    {
        if (thisObjectWarning == true)
        {
            startDespawnCounter = true;
        }
        if (startDespawnCounter == true)
        {
            DestroyTimer += Time.deltaTime;
        }
        //destruir prefab que tem a script
        if (DestroyTimer > setTimer)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
