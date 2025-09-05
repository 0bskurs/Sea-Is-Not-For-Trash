using System.Threading.Tasks;
using UnityEngine;

public class PrefabFall : MonoBehaviour
{
    public float fallSpeed = 2f; //velocidade de queda
    public Vector2 fallDirection = Vector2.down; //direcao da queda
    public float objectWeight = 1f;
    public bool isComputerPart;
    public bool touchedCollider;
    private void Start()
    {
        touchedCollider = false;
        
    }
    private void FixedUpdate()
    {
        if (this.gameObject.CompareTag("Coletavel") && touchedCollider == false)
        {
            transform.Translate(fallDirection * fallSpeed * Time.deltaTime * objectWeight);
        }
        else if (this.gameObject.CompareTag("Trash"))
        {
            transform.Translate(fallDirection * fallSpeed * Time.deltaTime * objectWeight);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Parar"))
        {   
            touchedCollider = true;
        }
    }
   
    
}
