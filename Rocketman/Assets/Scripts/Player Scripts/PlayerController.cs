using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public GameObject player;
    public Rigidbody rocket;
    public float rotationSpeed;
    public float ThrustAmount;

    public float gravityScale;
    public static float gravity = -9.8f;


    void Start()
    {
        rocket = player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(!rocket.useGravity)
        {
            Vector3 accelerationGravity = new Vector3(0, 1, 0);
            Debug.Log("Fake Gravity");
            rocket.AddForce(accelerationGravity * gravity * gravityScale, ForceMode.Acceleration);
        }

        float xAxis = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            ThrustForward();
        }
        Rotation(transform, -xAxis * rotationSpeed);
    }


    #region Movement

    private void ThrustForward()
    {
        Vector3 boost = transform.up * ThrustAmount;
        //Add boost when holding down space
        rocket.AddForce(boost);
    }

    private void Rotation(Transform r, float rspeed)
    {
        r.Rotate(0, 0, rspeed);
    }

    #endregion


    #region Fail Conditions

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay (Collider side)
    {
        Destroy(gameObject);
    }

    #endregion

}
