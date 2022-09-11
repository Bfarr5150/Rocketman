using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    public GameObject player;
    public Rigidbody rocket;
    public float rotationSpeed;
    public float ThrustAmount;

    public Boost boostBar;

    public float gravityScale;
    public static float gravity = -9.8f;

    public float maxFuel = 100f;
    public float minFuel = 0f;
    public static float currentFuel;
    public float fuelConsumedUpdate = .1f;

    public GameObject rocketBoost;
    public GameObject boostBar;

    void Start()
    {
        rocket = player.GetComponent<Rigidbody>();

        currentFuel = maxFuel;

        boostBar.SetMaxBoost(maxFuel);


        
    }

    void FixedUpdate()
    {
        // Use custom gravity scale if rigid body is not already simulating gravity.
        if (!rocket.useGravity)
        {
            Vector3 accelerationGravity = new Vector3(0, 1, 0);
            rocket.AddForce(accelerationGravity * gravity * gravityScale, ForceMode.Acceleration);
        }

        //Inputs
        float xAxis = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            ThrustForward();
        }
        else
        {
            StopThrust();
        }
        Rotation(transform, -xAxis * rotationSpeed);

        //Fuel updates
        if (currentFuel > minFuel)
        {
            boostBar.SetBoost(currentFuel);
        }

        // Win condition
        float distToGround = GetComponent<Collider>().bounds.extents.y;
        if (Physics.Raycast(player.transform.position, -Vector3.up, distToGround))
        {
            Debug.Log("Grounded");
            CheckWinCondition();
        }
    }

   


    #region Movement

    //Apply upwards thrust to slow fall
    private void ThrustForward()
    {
        // Consume and check fuel before we thrust
        currentFuel -= fuelConsumedUpdate;

        if(currentFuel < minFuel)
        {
            currentFuel = minFuel;
            StopThrust();
            return;
        }

        //Set Boost Bar amount
        boostBar.SetBoost(currentFuel);

        // Add thrust
        Vector3 boost = transform.up * ThrustAmount;
        rocket.AddForce(boost);
        rocketBoost.SetActive(true);
    }

    private void StopThrust()
    {
        rocketBoost.SetActive(false);
    }

    //Left-right rotation
    private void Rotation(Transform r, float rspeed)
    {
        r.Rotate(0, 0, rspeed);
    }

    #endregion


    #region Fail Conditions

    //Landing velocity
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SafeBlocking" || collision.gameObject.tag == "Fuel")
        {
            return;
        }
        else if (collision.gameObject.tag == "InstantKill" || collision.relativeVelocity.magnitude > 10)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
            return;
        }
    }

    //Landing on side
    private void OnTriggerStay (Collider side)
    {
        if(side.gameObject.tag == "SafeBlocking" || side.gameObject.tag == "Fuel")
        {
            return;
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fuel")
        {
            currentFuel += 10f;
            if(currentFuel > maxFuel)
            {
                currentFuel = maxFuel;
            }

            Destroy(other.gameObject);
        }
    }

    private void CheckWinCondition()
    {
        Vector3 velocity = rocket.velocity;
        float speed = velocity.magnitude;
        if(speed < .2f)
        {
            Debug.Log("Victory!");
            Time.timeScale = 0f;
        }
    }

    #endregion
}