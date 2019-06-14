using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour { 

    public float NaturalLag = 0f;
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    //Late Update is called at the end
    void LateUpdate()
    {
        Vector3 desiredPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * NaturalLag);
    }
}
