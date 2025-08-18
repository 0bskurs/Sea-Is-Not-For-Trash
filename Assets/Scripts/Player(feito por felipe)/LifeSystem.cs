using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int MaxLife = 2;
    [SerializeField] private int Currentlife;
    [SerializeField] private Image[] Lifes;

    private void Awake(){Currentlife = MaxLife;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            Debug.Log("Em contato");
            DisableImages();
        }
    }

    private void DisableImages()
    {
        Currentlife -= 1;
        Lifes[Currentlife].gameObject.SetActive(false);
        if(Currentlife <= 0) { Destroy(gameObject); } // Subtituir por uma troca de cena,SceneManagement
    }
}
