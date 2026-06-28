using UnityEngine;

public class MazeExitTrigger : MonoBehaviour
{
    public GameObject mainGate; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Fairy") 
        {
            Debug.Log("پری به آخر ماز رسید! در قلعه باز شد.");
            
            if (mainGate != null)
            {
                Destroy(mainGate);
            }
        }
    }
}