using UnityEngine;

public class MazeEndButton : MonoBehaviour
{
    public GameObject darknessLayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Fairy" && darknessLayer != null)
        {
            Destroy(darknessLayer);
        }
    }
}