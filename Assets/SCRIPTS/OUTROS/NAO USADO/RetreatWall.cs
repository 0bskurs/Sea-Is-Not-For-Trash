using UnityEngine;
using System.Collections;
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
            
            Debug.Log("Touching the wall!!");
            
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            movementScript.horizontalMovement = movementScript.horizontalMovement * -1f;
        }
    }
    public IEnumerator MethodWithDelay()
    {
        //some inital logic here

        yield return new WaitForSeconds(0.2f); //delay here
        movementScript.horizontalMovement = movementScript.horizontalMovement * -1f;
        //rest of logic here
    }

}
