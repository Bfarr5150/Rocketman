using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rocket;
    public float rotationSpeed;
    public float amount;

    // Start is called before the first frame update
    void Start()
    {
        rocket = player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Jump");
        float xAxis = Input.GetAxis("Horizontal");
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //ThrustForward(yAxis);
        if (Input.GetButton("Jump"))
        {
            ThrustForward();
        }
    }

    private void ClampVelocity()
    {

    }

    private void ThrustForward()
    {
        Vector3 boost = transform.up * amount;
        //Add boost when holding down space
        rocket.AddForce(boost);
    }





}

//Progressive momentum
//
