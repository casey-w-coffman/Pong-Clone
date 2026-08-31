using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //set default ball speed
    public float speed = 8f;

    //call rigidbody2d and set lastXDirection
    private Rigidbody2D rb;
    private float lastXDirection = 0f;

    //instance the script
    public static BallMovement Instance;

    void Awake()
    {
        Instance = this;
    }

    //call rigidbody2d rb, set gravity to zero, constrain ball to no rotation
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void LaunchBall()
    {
        float xDirection;

        //launch ball in opposite direction from before
        if (lastXDirection == 0f)
        {
            xDirection = Random.value < 0.5f ? -1f : 1f;
        }
        else
        {
            xDirection = -lastXDirection;
        }

        lastXDirection = xDirection;

        float yDirection = Random.Range(-0.25f, 0.25f);

        //launch ball in random, constrained direction
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * speed;
    }

    //detect collision with player paddle
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider2D paddleCollider = collision.collider;
            float paddleHeight = paddleCollider.bounds.size.y;

            //determine where on the paddle it was hit and transform the y bounce vector
            float paddleY = collision.transform.position.y;
            float hitPoint = (transform.position.y - paddleY) / (paddleHeight / 2f);
            hitPoint = Mathf.Clamp(hitPoint, -1f, 1f);

            //transform the x bounce vector
            float xDir = collision.transform.position.x < transform.position.x ? 1f : -1f;

            //bounce the ball
            Vector2 newDirection = new Vector2(xDir, hitPoint).normalized;
            rb.linearVelocity = newDirection * speed;

            //move the ball slightly off the player paddle to avoid jitter
            transform.position += (Vector3)(newDirection * 0.1f);
        }
    }

    //resetball if relaunch is true (only true in GameState playing)
    public void ResetBall(bool relaunch = true)
    {
        //reset location and vector to zero
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;

        //if relaunch is true, run LaunchBall
        if (relaunch)
        {
            LaunchBall();
        }
    }   
}