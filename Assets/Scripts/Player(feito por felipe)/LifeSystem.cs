using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.SceneManagement;
public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int MaxLife = 3;
    [SerializeField] private int Currentlife;
    [SerializeField] private GetAnimatorVida getAnimatorVida;
    [SerializeField] private int vida;
    
    
    [Header("How much until other game object is destroyed (in milliseconds).")][SerializeField] private int waitForTask;

    
    private void Start()
    {
        Currentlife = MaxLife;


        
        vida = MaxLife;
        if (getAnimatorVida.animator = null)
        {
            Debug.LogWarning("Faltando Animator!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
           
            Debug.Log("Em contato");
            Invoke("DisableImages", 0.1f);
            Destroy(other.gameObject);
            
        }
    }
    
    
    async Task DisableImages()
    {
        await Task.Delay(500);
        Currentlife -= 1;
        vida = Currentlife;
        getAnimatorVida.animator.SetFloat("Vida", vida);

        if (Currentlife <= 0) 
        {
            
            await Task.Delay(2000);
            SceneManager.LoadSceneAsync(2);
        } // Subtituir por uma troca de cena,SceneManagement


    }
    

}
