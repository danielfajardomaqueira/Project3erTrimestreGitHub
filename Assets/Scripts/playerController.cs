using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    
    public float rotSpeed = 100f;
    public float speed = 10f;
    public float turnSpeed = 350f;
    public float horizontalInput;
    private float verticalInput;
    public float horizontalMouse;

    bool isJump = false;
    public float jumpForce = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar el Input Horizontal
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        horizontalMouse = Input.GetAxis("Mouse X");
        //Movimiento hacia adelante
        //transform.Translate(0, 0, 1);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        // Movimiento lateral manual
        //transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        isJump = Input.GetButtonDown("Jump");

        if (isJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
