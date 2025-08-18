using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ColetaItem : MonoBehaviour
{
    public bool thatObjectCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            Debug.Log("Colatado " + other.name);
            Destroy(other.gameObject);
            thatObjectCollected = true;
        }
    }
}
