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

        // کنترل‌های شوالیه (Knight)
        if (gameObject.name == "Knight")
        {
            if (Input.GetKey(KeyCode.A)) moveX = -1f;
            if (Input.GetKey(KeyCode.D)) moveX = 1f;
            if (Input.GetKey(KeyCode.W)) moveY = 1f;
            if (Input.GetKey(KeyCode.S)) moveY = -1f;
        }
        // کنترل‌های پری (Fairy)
        else if (gameObject.name == "Fairy")
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
            if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;
        }

        // اعمال سرعت در هر دو محور X و Y برای بازی‌های دید از بالا
        // (Normalize استفاده میشه تا سرعت حرکت مورب از حالت عادی بیشتر نشه)
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * speed;
    }
}