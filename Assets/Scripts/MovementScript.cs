using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    
    public float speed = 1f;
    [SerializeField] private InputAction playerController;
    bool isColliding;
    [SerializeField] private Rigidbody2D _rigidbody;
    Vector2 movement = Vector2.zero;
    GameObject _gameObject;
    
    float horizontalMovement;

    private void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        movement = new Vector2(horizontalMovement, 0);
        _rigidbody.linearVelocity = movement * speed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    
}
