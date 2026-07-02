using UnityEngine;
using System.Collections;

public class FairyHurt : MonoBehaviour
{
    public Transform mazeExitPoint;
    public Transform knightStartPoint;
    public Transform knightTransform;
    private bool isHurt = false;

    private Color fairyOriginalColor;
    private Color knightOriginalColor;

    void Start()
    {
        fairyOriginalColor = GetComponent<SpriteRenderer>().color;
        if (knightTransform != null)
        {
            knightOriginalColor = knightTransform.GetComponent<SpriteRenderer>().color;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Spikes" && other.GetComponent<SpriteRenderer>().color == Color.red && !isHurt)
        {
            isHurt = true;
            StartCoroutine(ResetPlayersPath());
        }
    }

    IEnumerator ResetPlayersPath()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<DualPlayerController>().enabled = false;

        if (knightTransform != null)
        {
            knightTransform.GetComponent<DualPlayerController>().enabled = false;
            knightTransform.GetComponent<SpriteRenderer>().color = Color.red;
        }

        yield return new WaitForSeconds(1.0f);

        if (mazeExitPoint != null)
        {
            transform.position = mazeExitPoint.position;
        }

        if (knightTransform != null && knightStartPoint != null)
        {
            knightTransform.position = knightStartPoint.position;
        }

        GetComponent<SpriteRenderer>().color = fairyOriginalColor;
        GetComponent<DualPlayerController>().enabled = true;

        if (knightTransform != null)
        {
            knightTransform.GetComponent<SpriteRenderer>().color = knightOriginalColor;
            knightTransform.GetComponent<DualPlayerController>().enabled = true;
        }

        isHurt = false;
    }
}