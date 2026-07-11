using UnityEngine;

public class BridgeSwitch : MonoBehaviour
{
    public Transform bridge;
    public float speed = 5f;
    
    public Collider2D waterUnderBridgeCollider; 
    
    private bool isActivated = false;

    void Update()
    {
        if (isActivated && bridge != null && waterUnderBridgeCollider != null)
        {
            bridge.position = Vector3.MoveTowards(
                bridge.position, 
                waterUnderBridgeCollider.transform.position, 
                speed * Time.deltaTime
            );
            
            if (waterUnderBridgeCollider.enabled)
            {
                waterUnderBridgeCollider.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Knight")
        {
            isActivated = true;
        }
    }
}