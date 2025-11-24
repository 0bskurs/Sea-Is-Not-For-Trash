using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class ColetaItem : MonoBehaviour
{
    public bool gpuCollected = false;
    public bool processadorCollected = false;
    public bool placaMaeCollected = false;
    public bool gabineteCollected = false;
    [SerializeField] private List<GameObject> coletaItemDelete;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GPU"))
        {
            gpuCollected = true;
            Debug.Log("Coletado " + other.name);
            Destroy(coletaItemDelete[0]);

        }
        if (other.CompareTag("Processador"))
        { 
            processadorCollected = true;
            Debug.Log("Coletado " + other.name);
            Destroy(coletaItemDelete[1]);
        }
        if (other.CompareTag("Placa Mae"))
        {
            placaMaeCollected = true;
            Debug.Log("Coletado " + other.name);
            Destroy(coletaItemDelete[2]);
        }
        if (other.CompareTag("Gabinete"))
        {
            gabineteCollected = true;
            Debug.Log("Coletado " + other.name);
            Destroy(coletaItemDelete[3]);
        }
    }
}

