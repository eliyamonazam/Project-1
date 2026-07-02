using UnityEngine;

public class DualPlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        
        if (gameObject.name == "Knight")
        {
            if (Input.GetKey(KeyCode.A)) moveX = -1f;
            if (Input.GetKey(KeyCode.D)) moveX = 1f;
            if (Input.GetKey(KeyCode.W)) moveY = 1f;
            if (Input.GetKey(KeyCode.S)) moveY = -1f;
        }
        else if (gameObject.name == "Fairy")
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
            if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;
        }
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * speed;
    }
}