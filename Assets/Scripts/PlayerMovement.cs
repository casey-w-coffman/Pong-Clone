using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minY = -3.975f;
    public float maxY = 4.025f;

    public Key upKey = Key.W;
    public Key downKey = Key.S;

    public Vector2 startPosition;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
    if (GameManager.Instance.currentState != GameManager.GameState.Playing)
    {
        rb.position = startPosition;
        return;
    }

        float moveVertical = 0f;

        if (Keyboard.current[upKey].isPressed)
        {
            moveVertical = 1f;
        }
        else if (Keyboard.current[downKey].isPressed)
        {
            moveVertical = -1f;
        }

        Vector2 movement = new Vector2(0f, moveVertical) * speed * Time.fixedDeltaTime;
        Vector2 newPosition = rb.position + movement;

        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        rb.MovePosition(newPosition);
    }
}