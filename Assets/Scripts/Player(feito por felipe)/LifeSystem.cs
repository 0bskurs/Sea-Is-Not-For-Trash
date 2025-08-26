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

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            await Task.Delay(waitForTask);
            Debug.Log("Em contato");
            DisableImages();
            Destroy(other.gameObject);
        }
    }

    private void DisableImages()
    {
        Currentlife -= 1;
        Lifes[Currentlife].gameObject.SetActive(false);
        if(Currentlife <= 0) { Destroy(gameObject); } // Subtituir por uma troca de cena,SceneManagement
    }
    
}
