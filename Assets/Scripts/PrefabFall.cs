using UnityEngine;

public class PrefabFall : MonoBehaviour
{
    public float fallSpeed = 2f; //velocidade de queda
    public Vector2 fallDirection = Vector2.down; //direcao da queda
    public float objectWeight = 1f;

    void Update()
    {
        // mover o objeto e a direcao que cai
        transform.Translate(fallDirection * fallSpeed * Time.deltaTime * objectWeight);
    }
}
