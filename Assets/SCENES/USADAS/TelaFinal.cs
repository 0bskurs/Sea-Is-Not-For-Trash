using UnityEngine;
using UnityEngine.SceneManagement;
public class TelaFinal : MonoBehaviour
{
    [SerializeField] float time = 0;
    [SerializeField] Animator animatorSombra;
    [SerializeField] GameObject button;
    private void Start()
    {
        time = 0;
        animatorSombra.SetBool("Sombra", false);
        button.SetActive(false);
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }
    private void Update()
    {
        if (time >= 8)
        {
            button.SetActive(true);
            animatorSombra.SetBool("Sombra", true);
        }
    }
    public void Creditos()
    {
        SceneManager.LoadSceneAsync(9);
    }
}
