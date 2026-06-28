using UnityEngine;

public class DualPlayerController : MonoBehaviour
{
    public enum PlayerType { Knight, Fairy }
    public PlayerType playerType;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    private Rigidbody2D rb;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode jumpKey;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (playerType == PlayerType.Knight) {
            leftKey = KeyCode.A;
            rightKey = KeyCode.D;
            jumpKey = KeyCode.W;
        } else {
            leftKey = KeyCode.LeftArrow;
            rightKey = KeyCode.RightArrow;
            jumpKey = KeyCode.UpArrow;
        }
    }

    void Update()
    {
        float moveInput = 0f;
        if (Input.GetKey(leftKey)) moveInput = -1f;
        if (Input.GetKey(rightKey)) moveInput = 1f;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(jumpKey)) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}