using UnityEngine;

public class WaterTrapMission1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.GetComponent<Health>()?.Die(); 
        }
    }
}