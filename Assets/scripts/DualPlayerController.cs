using UnityEngine;

public class DualPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float jumpCooldown = 0.5f;
    
    private Rigidbody2D rb;
    private float nextJumpTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = 0f;
        bool jumpPressed = false;

        if (gameObject.name == "Knight")
        {
            if (Input.GetKey(KeyCode.A)) moveX = -1f;
            if (Input.GetKey(KeyCode.D)) moveX = 1f;
            if (Input.GetKeyDown(KeyCode.W)) jumpPressed = true;
        }
        else if (gameObject.name == "Fairy")
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
            if (Input.GetKeyDown(KeyCode.UpArrow)) jumpPressed = true;
        }

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (jumpPressed && Time.time >= nextJumpTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            nextJumpTime = Time.time + jumpCooldown;
        }
    }
}