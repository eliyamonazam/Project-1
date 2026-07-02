using UnityEngine;

public class BridgeSwitch : MonoBehaviour
{
    public Transform bridge;
    public Vector3 targetBridgePosition;
    public float speed = 5f;

    public GameObject waterUnderBridge; 
    
    private bool isActivated = false;

    void Update()
    {
        if (isActivated && bridge != null)
        {
            bridge.position = Vector3.MoveTowards(bridge.position, targetBridgePosition, speed * Time.deltaTime);
            
        
            if (waterUnderBridge != null)
            {
                waterUnderBridge.SetActive(false);
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