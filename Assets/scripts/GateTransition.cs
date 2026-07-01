using UnityEngine;

public class GateTransition : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Knight") 
        {
            Debug.Log("شوالیه به در رسید! سنسور با موفقیت فعال شد.");
        }
    }
}