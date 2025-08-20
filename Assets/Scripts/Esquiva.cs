using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEditor;
public class Esquiva : MonoBehaviour
{
    private Vector2 playerPosition;
    [SerializeField] GameObject player;
    [SerializeField] private InputAction PlayerController;
    [SerializeField] public InputActionReference inputActionReference;
    [SerializeField] private bool isOnCooldown = false;
    [SerializeField] private float cooldownTime = 5f;
    
    private bool keyPressed;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private System.Collections.IEnumerator DisableCollisionTemporarily()
    {
        isOnCooldown = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(cooldownTime);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        isOnCooldown = false;
    }
    public void OnToggleCollision(InputAction.CallbackContext context)
    {
        
        if (context.performed && !isOnCooldown)
        {
            StartCoroutine(DisableCollisionTemporarily());
        }
    }

}
