using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //setting default speed and limits of movement
    public float speed = 5f;
    public float minY = -3.975f;
    public float maxY = 4.025f;

    //setting default up/down keys, change in inspector to up/down arrow for right player
    public Key upKey = Key.W;
    public Key downKey = Key.S;

    //set startPosition to 0,0, changed in inspector to correct positions
    public Vector2 startPosition;

    //call and define rigidbody2d
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //if not gamestate playing, set the paddles to 0,0
    void FixedUpdate()
    {
    if (GameManager.Instance.currentState != GameManager.GameState.Playing)
    {
        rb.position = startPosition;
        return;
    }

    //set default vertical movement to 0,0
    float moveVertical = 0f;

    //change vertical movement to 0,1 if up key or 0,-1 if down key
    if (Keyboard.current[upKey].isPressed)
    {
        moveVertical = 1f;
    }
    else if (Keyboard.current[downKey].isPressed)
    {
        moveVertical = -1f;
    }

    //apply vector movement and direction
    Vector2 movement = new Vector2(0f, moveVertical) * speed * Time.fixedDeltaTime;
    Vector2 newPosition = rb.position + movement;

    //clamp the player movement to the min and max x/y defined above
    newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

    rb.MovePosition(newPosition);
    }
}