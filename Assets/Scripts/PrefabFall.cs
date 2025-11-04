using System.Data;
using System.Threading.Tasks;
using UnityEngine;

public class PrefabFall : MonoBehaviour
{
    public float fallSpeed; //velocidade de queda
    public float speed;
    public Vector2 fallDirection = Vector2.down; //direcao da queda
    public float objectWeight = 1f;
    public bool isComputerPart;
    public bool touchedCollider;
    public bool triggerActivated;
    [SerializeField] private Warning warning;
    
    private void Start()
    {
       
        speed = 0;
        touchedCollider = false;
        triggerActivated = false;
    }
    private void FixedUpdate()
    {
        if (triggerActivated == true)
        {
            speed = fallSpeed;
            this.gameObject.transform.Translate(fallDirection * speed * Time.deltaTime * objectWeight);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Parar")))
        {
            touchedCollider = true;

        }
        if (triggerActivated == true && collision.gameObject.CompareTag("warningOff"))
        {
            warning.WarningOff = true;
            Destroy(collision.gameObject);
        }
    }
   
    
}
