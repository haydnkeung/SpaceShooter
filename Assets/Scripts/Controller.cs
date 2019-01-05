using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{


    private Rigidbody2D rb;

    public GameObject missile;

    public float forwardSpeed = 0.1f;
    public float rotationSpeed = 5;

    public float missileDelay = 1;
    public float timeLastFired = 0;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        checkInput();
    }

    private void checkInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        rotate(xInput * -rotationSpeed);
        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
            transform.position += transform.up * forwardSpeed;
        if (Input.GetKey(KeyCode.Space) && Time.time-timeLastFired > missileDelay) {
            Instantiate(missile, transform.position + transform.up, transform.rotation);
            timeLastFired = Time.time;
        }
        

    }

    private void rotate(float amount) {

        transform.Rotate(0, 0, amount);   

    }
}
