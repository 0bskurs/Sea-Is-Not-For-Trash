using System.Threading.Tasks;
using UnityEngine;

public class GetAnimatorVida : MonoBehaviour
{
    public Animator animator;
    
    private void Start()
    {
        Invoke("GetAnimator", 0.3f);
    }
    async Task GetAnimator()
    {
        await Task.Delay(1000);
        animator = GetComponent<Animator>();
    }
}
