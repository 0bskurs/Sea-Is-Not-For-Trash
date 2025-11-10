using UnityEngine;
using System.Threading.Tasks;
public class GetAnimatorTinta : MonoBehaviour
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
