using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour { 

    public float NaturalLag = 0f;
    public GameObject player;
    private Vector3 offset;

    public bool MouseControl = false;
    public bool MouseMove = false;
    public bool MouseRotate = true;
    public bool Orbital = false;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float HorizontalSense = 1.0f;
    public float VerticalSense = 1.0f;

    public float Sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    //Late Update is called at the end
    void LateUpdate()
    {

        if (MouseControl)
        {
            if (MouseMove)
            {
                transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensitivity, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensitivity);
            }
            if (MouseRotate & !Orbital)
            {
                yaw += HorizontalSense * Input.GetAxis("Mouse X");
                pitch -= VerticalSense * Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            }
            if (MouseRotate & Orbital)
            {
                Quaternion yaw = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * HorizontalSense, Vector3.up);
                Quaternion pitch = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * VerticalSense, Vector3.left);
                offset = yaw * offset;
                offset = pitch * offset;
                
            }
        }

        //apply all transforms with a lerp
        Vector3 desiredPos = player.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, desiredPos, Time.deltaTime * NaturalLag);
        if (MouseRotate && Orbital) { transform.LookAt(player.transform); } //needs to be applied after if enabled
    }
}
