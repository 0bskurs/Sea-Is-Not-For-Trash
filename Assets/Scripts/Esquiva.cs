using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEditor;
using System.Threading.Tasks;
public class Esquiva : MonoBehaviour
{
    private Vector2 playerPosition;
    [SerializeField] GameObject player;
    [SerializeField] GameObject tintaSprite;
    [SerializeField] GameObject barraTintaSprite;
    [SerializeField] private InputAction PlayerController;
    [SerializeField] public InputActionReference inputActionReference;
    [SerializeField] private bool isOnCooldown = false;
    [SerializeField] private int cooldownTime = 2;
    [SerializeField] private int invincibilityTime = 1;
    [SerializeField] Animator tintaAnimator;
    [SerializeField] Animator barraTintaAnimator;
    public bool isOnPause;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GetAnimatorTinta getAnimatorTinta;
    private bool keyPressed;
    private void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        
    }
    private void FixedUpdate()
    {
        
    }
    private async Task DisableCollisionTemp()
    {
        if (isOnPause == false)
        {
            
            getAnimatorTinta.animator.SetBool("Started", true);
            getAnimatorTinta.animator.SetBool("Full", false);
            await Task.Delay(invincibilityTime * 100);
            isOnCooldown = true;
            Physics2D.IgnoreLayerCollision(6, 7, true);
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            await Task.Delay(invincibilityTime * 900);
            getAnimatorTinta.animator.SetBool("Full", true);
            Physics2D.IgnoreLayerCollision(6, 7, false);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            await Task.Delay(cooldownTime * 900);
            await Task.Delay(cooldownTime * 100);
            isOnCooldown = false;
        }
        if (isOnPause == true)
        {
            Debug.Log("TELA PAUSADA!!!! SCRIPT DE ESQUIVA!!!");
        }
    }
    private async Task EnableDisableSprite()
    {
        Vector3 player_position = player.transform.position;
        var prefabCopy = Instantiate(tintaSprite, player_position, Quaternion.identity);
        await Task.Delay(3000);
        Destroy(prefabCopy, 0.1f);
        
    }
    
    public void OnToggleCollision2D(InputAction.CallbackContext context)
    {
        
        if (context.performed && !isOnCooldown==true)
        {
            Invoke(nameof(DisableCollisionTemp), 0);
            Invoke(nameof(EnableDisableSprite), 0);
        }
    }

}
