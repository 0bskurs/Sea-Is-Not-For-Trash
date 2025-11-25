using UnityEngine;
using UnityEngine.SceneManagement;
public class DespawnPC : MonoBehaviour
{
    [SerializeField] private bool isComputerPart;
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Reiniciar") && isComputerPart == true)
        {
            Physics2D.IgnoreLayerCollision(6, 7, false);
            SceneManager.LoadSceneAsync(2);
        }
    }
}
