using UnityEngine;

public class MazeExitTrigger : MonoBehaviour
{
    public GameObject mainGate; 
    public Display cameraScript; 
    
    public Transform knightTransform; 


    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.name == "Fairy")
        {
            if (cameraScript != null)
            {
                cameraScript.Player2 = knightTransform; 
            }
        }
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