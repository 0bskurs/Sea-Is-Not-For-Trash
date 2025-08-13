using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    
    public float speed = 1f;
    [SerializeField] private InputAction PlayerController;
    bool isColliding;
    [SerializeField] private Rigidbody2D _rigidbody;
    Vector2 movement = Vector2.zero;
    GameObject _gameObject;
    
    private void OnEnable()
    {
        PlayerController.Enable();
    }
    private void OnDisable()
    {
        PlayerController.Disable();
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        movement = PlayerController.ReadValue<Vector2>();
        Debug.Log(movement.x);
       _rigidbody.linearVelocity = new Vector2(movement.x * speed,0);

    }
}
