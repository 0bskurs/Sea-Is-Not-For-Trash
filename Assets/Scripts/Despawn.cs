using UnityEngine;

public class Despawn : MonoBehaviour
{
    //cordenada Y para condicao
    [SerializeField] private float DestroyTimer;
    [SerializeField] private float setTimer;
    void Update()
    {
        DestroyTimer += Time.deltaTime;
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
