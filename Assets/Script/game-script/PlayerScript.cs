using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float deathYThreshold;
    public Vector3 spawnPosition;
    public float moveSpeed = 10;
    public float jumpForce = 5f;
    public Animator playerAnimator;
    public SpriteRenderer PlayerSprite;
    public float minX = -10f; // set your left bound
    public float maxX = 10f;  // set your right bound

    private bool isGrounded = false;
    private float horizontalInput;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        // Handle horizontal input (A/D or Left/Right arrows)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Handle jump input
        if ((Input.GetKeyDown(KeyCode.Space) ||
             Input.GetKeyDown(KeyCode.W) ||
             Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Check if player fell below threshold
        if (transform.position.y < deathYThreshold)
        {

            Respawn();
            //AudioManager.Instance.PlayGameOverMusic();
        }
        if (GameManager.Instance.lifeCount<=0)
        {
            UIManager.Instance.ShowLosePanel();
        }
    }

    void FixedUpdate()
    {
        // Move player
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Clamp player position within X range
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Handle animations and sprite flipping
        playerAnimator.SetBool("RUN", Mathf.Abs(horizontalInput) > 0);
        playerAnimator.SetBool("JUMP", !isGrounded);

        if (horizontalInput < 0) PlayerSprite.flipX = true;
        else if (horizontalInput > 0) PlayerSprite.flipX = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
        rb.velocity = Vector2.zero;
        isGrounded = false;
        GameManager.Instance.LoseLife(1);
        FindObjectOfType<LifeUIController>().UpdateLifeUI(GameManager.Instance.lifeCount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
           Respawn();
        }
    }
}
