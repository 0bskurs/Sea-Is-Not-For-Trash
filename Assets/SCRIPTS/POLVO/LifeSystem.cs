using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int MaxLife = 3;
    public int Currentlife = 3;
    [SerializeField] private List<Image> _healthSprites;
    //[SerializeField] private GetAnimatorVida getAnimatorVida;
    //[SerializeField] private int vida;

    [SerializeField] private int whichHeartEnableDisable;
    [Header("How much until other game object is destroyed (in milliseconds).")][SerializeField] private int waitForTask;
    [SerializeField] public bool died = false;

    
    private void Start()
    {
        Currentlife = MaxLife;
        whichHeartEnableDisable = MaxLife - 1;

        
        //vida = MaxLife;
        //if (getAnimatorVida.animator = null)
        //{
        //    Debug.LogWarning("Faltando Animator!");
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
           
            Debug.Log("Em contato com lixo");
            Invoke("DisableImages", 0f);
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);

        }
        //if (other.CompareTag("Heal"))
        //{

        //    Debug.Log("Em contato com cura");
        //    Invoke("EnableImages", 0.1f);
        //    Destroy(other.transform.parent.gameObject);

        //}
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillObject"))
        {
            Debug.Log("Em contato com parede");
            Invoke("Die", 0f);
            died = true;
        }
    }

    async Task DisableImages()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);

        if (whichHeartEnableDisable != -1)
        {
            _healthSprites[whichHeartEnableDisable].enabled = false;
        }
        Currentlife -= 1;
        //vida = Currentlife;
        whichHeartEnableDisable -= 1;

        //getAnimatorVida.animator.SetFloat("Vida", vida);

        if (Currentlife <= 0)
        {
            Physics2D.IgnoreLayerCollision(6, 7, false);
            await Task.Delay(1000);
            SceneManager.LoadSceneAsync(2);
        } // Subtituir por uma troca de cena,SceneManagement
        await Task.Delay(3000);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }
    async Task Die()
    {
        

        //if (whichHeartEnableDisable != -1)
        //{
        //    for (int i = 0; i < _healthSprites.Count; i++)
        //    {
        //        _healthSprites[i].enabled = false;
        //    }
        //}
        Currentlife = 0;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        await Task.Delay(1000);
        SceneManager.LoadSceneAsync(2);
        

    }
    private void OnDisable()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    //async Task EnableImages()
    //{
    //    if (Currentlife < MaxLife && Currentlife > 0)
    //    {
    //        Physics2D.IgnoreLayerCollision(6, 7, true);
    //        Currentlife += 1;
    //        whichHeartEnableDisable += 1;
    //        await Task.Delay(250);
    //        _healthSprites[whichHeartEnableDisable].enabled = true;
    //        await Task.Delay(1250);
    //        Physics2D.IgnoreLayerCollision(6, 7, false);

    //    }
    //    //Currentlife += 1;
    //    //if (whichHeartEnableDisable != -1 && Currentlife < MaxLife)
    //    //{
    //    //    _healthSprites[whichHeartEnableDisable].enabled = true;
    //    //}
    //    //if (Currentlife > MaxLife)
    //    //{
    //    //    Currentlife = MaxLife;
    //    //    Physics2D.IgnoreLayerCollision(6, 7, false);
    //    //}
    //    //vida = Currentlife;
    //    //getAnimatorVida.animator.SetFloat("Vida", vida);
    //}

    }
