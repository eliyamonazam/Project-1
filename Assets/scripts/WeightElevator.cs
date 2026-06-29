using UnityEngine;

public class WeightElevator : MonoBehaviour
{
    public Transform connectedPlatform;
    public float speed = 3f;

    private bool isHeavyLoaded = false;
    private float knightPlatformStartY;
    private float fairyPlatformStartY;

    void Start()
    {
        knightPlatformStartY = transform.position.y;
        if (connectedPlatform != null)
        {
            fairyPlatformStartY = connectedPlatform.position.y;
        }
    }

    void Update()
    {
        if (isHeavyLoaded)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, fairyPlatformStartY, transform.position.z), speed * Time.deltaTime);
            if (connectedPlatform != null)
            {
                connectedPlatform.position = Vector3.MoveTowards(connectedPlatform.position, new Vector3(connectedPlatform.position.x, knightPlatformStartY, connectedPlatform.position.z), speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, knightPlatformStartY, transform.position.z), speed * Time.deltaTime);
            if (connectedPlatform != null)
            {
                connectedPlatform.position = Vector3.MoveTowards(connectedPlatform.position, new Vector3(connectedPlatform.position.x, fairyPlatformStartY, connectedPlatform.position.z), speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Knight")
        {
            isHeavyLoaded = true;
            collision.transform.SetParent(transform); 
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Knight")
        {
            isHeavyLoaded = false;
            collision.transform.SetParent(null); 
        }
    }
}