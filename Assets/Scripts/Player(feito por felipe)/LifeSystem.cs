using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int MaxLife = 2;
    [SerializeField] private int Currentlife;
    [SerializeField] private Image[] Lifes;
    [Header("How much until other game object is destroyed (in milliseconds).")][SerializeField] private int waitForTask;

    private void Awake(){Currentlife = MaxLife;}
    private void Start()
    {
        
    }
    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            Debug.Log("Em contato");
            Invoke("DisableImages",0.1f);
            Destroy(other.gameObject);
        }
    }

    async Task DisableImages()
    {
        Currentlife -= 1;
        if (Currentlife <= 0) { Destroy(this.gameObject); } // Subtituir por uma troca de cena,SceneManagement
    }
    
}
