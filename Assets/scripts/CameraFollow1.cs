using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow1 : MonoBehaviour
{

    [SerializeField] public GameObject thingToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0, -10);
    }
}
