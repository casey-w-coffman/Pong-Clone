using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb;
    private float lastXDirection = 0f;

    public static BallMovement Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void LaunchBall()
    {
        float xDirection;

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

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider2D paddleCollider = collision.collider;
            float paddleHeight = paddleCollider.bounds.size.y;

            float paddleY = collision.transform.position.y;
            float hitPoint = (transform.position.y - paddleY) / (paddleHeight / 2f);
            hitPoint = Mathf.Clamp(hitPoint, -1f, 1f);

            float xDir = collision.transform.position.x < transform.position.x ? 1f : -1f;

            Vector2 newDirection = new Vector2(xDir, hitPoint).normalized;
            rb.linearVelocity = newDirection * speed;
            transform.position += (Vector3)(newDirection * 0.1f);
        }
    }

    public void ResetBall(bool relaunch = true)
    {
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;

        if (relaunch)
        {
            LaunchBall();
        }
    }   
}