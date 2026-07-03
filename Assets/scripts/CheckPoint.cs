using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 knightPos, fairyPos;
    private static bool init = false;

    void Start()
    {
        if (!init) 
        {
            knightPos = GameObject.Find("Knight").transform.position;
            fairyPos = GameObject.Find("Fairy").transform.position;
            init = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Knight" || col.name == "Fairy")
        {
            knightPos = GameObject.Find("Knight").transform.position;
            fairyPos = GameObject.Find("Fairy").transform.position;
        }
    }
}