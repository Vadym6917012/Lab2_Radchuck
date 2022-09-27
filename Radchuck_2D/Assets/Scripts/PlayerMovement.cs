using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float playerJumpForce = 5f;

    private Vector2 _movementVector;
    Rigidbody2D _rbody;

    void Start()
    { 
        _rbody = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        Vector2 playerVelocity = new Vector2(_movementVector.x * playerSpeed, _rbody.velocity.y);
        _rbody.velocity = playerVelocity;
    }

    private void OnMove(InputValue value)
    {
        _movementVector = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && Mathf.Abs(_rbody.velocity.y) < 0.5f)
        {
            _rbody.velocity += new Vector2(0f, playerJumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
