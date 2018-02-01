using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;

    //public Camera mrc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if( count >= 12)
        {
            winText.text = "You Win!";
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Vector3 forward = mrc.transform.TransformDirection(Vector3.forward);
        //Vector3 right = mrc.transform.TransformDirection(Vector3.right);
        //movement =Input.GetAxis("Vertical") * forward + Input.GetAxis("Horizontal") * right;

        //movement = movement + Input.GetAxis("TouchPad RY") * forward + Input.GetAxis("TouchPad RX") * right;

        rb.AddForce(movement * speed );


    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

}
