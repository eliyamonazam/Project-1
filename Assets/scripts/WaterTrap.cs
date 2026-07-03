using UnityEngine;

public class WaterTrap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Knight" || col.name == "Fairy")
        {
            GameObject.Find("Knight").transform.position = Checkpoint.knightPos;
            GameObject.Find("Fairy").transform.position = Checkpoint.fairyPos;
        }
    }
}