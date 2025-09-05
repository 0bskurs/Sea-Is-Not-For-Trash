using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColetaItem : MonoBehaviour
{
    public bool thatObjectCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            thatObjectCollected = true;
            Debug.Log("Colatado " + other.name);
            Invoke("ChangeScene", 0.1f);

        }
    }
    async Task ChangeScene()
    {
        await Task.Delay(3500);
        SceneManager.LoadSceneAsync(3);

    }
}

