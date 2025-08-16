using UnityEngine;

public class Despawn : MonoBehaviour
{
    //cordenada Y para condicao
    public float destroyYCoordinate = -5f;

    void Update()
    {
        // checar a posicao Y
        if (transform.position.y < destroyYCoordinate)
        {
            //destruir prefab que tem a script
            Destroy(gameObject);
        }
    }
}
