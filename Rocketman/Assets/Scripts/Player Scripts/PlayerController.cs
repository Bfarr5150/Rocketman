using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rocket;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rocket = player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        ThrustForward(yAxis);
    }

    private void ClampVelocity()
    {

    }

    private void ThrustForward(float amount)
    {
        Vector3 boost = transform.up * amount;
        //Add boost when holding down space
        rocket.AddForce(boost);
    }





}

//Progressive momentum
//
