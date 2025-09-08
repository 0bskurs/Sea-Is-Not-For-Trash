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
    [SerializeField] private InputAction PlayerController;
    [SerializeField] public InputActionReference inputActionReference;
    [SerializeField] private bool isOnCooldown = false;
    [SerializeField] private int cooldownTime = 15;
    [SerializeField] private int invincibilityTime = 3;

    private bool keyPressed;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private async Task DisableCollisionTemp()
    {
        isOnCooldown = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        await Task.Delay(invincibilityTime * 1000);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        await Task.Delay(cooldownTime * 1000);
        isOnCooldown = false;
    }
    
    public void OnToggleCollision2D(InputAction.CallbackContext context)
    {
        
        if (context.performed && !isOnCooldown==true)
        {
            Invoke(nameof(DisableCollisionTemp), 0);

        }
    }

}
