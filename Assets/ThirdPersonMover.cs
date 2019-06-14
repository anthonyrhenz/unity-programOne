using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ThirdPersonMover : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    Animator animator;
    public Text dbgtxt;
    private float h;
    private float v;
    private bool jmp;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        jmp = Input.GetKey(KeyCode.Space);

        //jump
        if (jmp) { animator.SetBool("jump", true); }
        else { animator.SetBool("jump", false); }
        //sprint
        if (Input.GetKey(KeyCode.LeftShift)) { if (speed < 10) { speed += 0.02f; } }
        else { if (speed>3) { speed -= 0.05f; } }

        animator.SetFloat("speed", (Math.Abs(h) + Math.Abs(v))*speed);
        

        //rb.AddForce(new Vector3(h, 0.0f, v) * speed);
        transform.Translate(h*Time.deltaTime*speed, 0f, v*Time.deltaTime*speed );
    }

    void LateUpdate()
    {
        var debugstring = ((h + v)*speed).ToString() + "\n" + "dTime:" + Time.deltaTime.ToString() ;
        dbgtxt.text = debugstring;
    }
}
