using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Display : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;
    public float smoothSpeed = 5f;

    public float minZ = 5f;
    public float maxZ = 10f;
    public float zoomLimiter = 15f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        Vector3 center = (Player1.position + Player2.position) / 2f;
        transform.position = new Vector3(center.x , center.y , -10f);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(Player1 == null || Player2 == null)
        {
            return;
        }
       Vector3 center = (Player1.position + Player2.position) / 2f;

       Vector3 target = new Vector3(center.x , center.y, -10f);

        transform.position = Vector3.Lerp(transform.position , target , smoothSpeed * Time.deltaTime);

        float distance = Vector2.Distance(Player1.position , Player2.position);

        float newZoom = Mathf.Lerp(minZ , maxZ , distance / zoomLimiter);

        
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize , Mathf.Clamp(newZoom , minZ , maxZ) , Time.deltaTime * smoothSpeed);


    }
}
