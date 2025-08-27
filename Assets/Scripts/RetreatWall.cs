using UnityEngine;

public class RetreatWall : MonoBehaviour
{
    [SerializeField] private MovementScript movementScript;
    [SerializeField] private float speedInvert;
    private void Start()
    {
        movementScript = GetComponent<MovementScript>();
         
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            movementScript.horizontalMovement = movementScript.horizontalMovement * -1f;
            Debug.Log("Touching the wall!!");
        }
    }
    
}
