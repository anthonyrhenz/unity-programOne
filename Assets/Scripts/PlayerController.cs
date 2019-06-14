using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //definitions 
    public Rigidbody rb;

    public Text countText;
    public Text winText;

    public float speed = 1f;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setCountText();
        winText.text = "";
    }

    void FixedUpdate() //called before physics calcs
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }

    void setCountText ()
    {
        countText.text = "Score: " + count.ToString();
        if (count == 4)
        {
            winText.text = "You win?";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
