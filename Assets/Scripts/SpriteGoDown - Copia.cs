using System.Threading.Tasks;
using UnityEngine;

public class SpriteGoDown : MonoBehaviour
{
    [SerializeField] private float startTime;
    private float time;
    [SerializeField] private GameObject _object;
    public Vector2 fallDirection = Vector2.up;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float stopTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (this.gameObject.CompareTag("Scenery") && time < stopTime && time > startTime)
        {
            transform.Translate(fallDirection * fallSpeed * Time.deltaTime);
        }
    }
}
