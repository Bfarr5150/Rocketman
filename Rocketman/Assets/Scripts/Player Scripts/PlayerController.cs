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

    public float gravityScale;
    public static float gravity = -9.8f;

    public float maxFuel = 100f;
    public float minFuel = 0f;
    public static float currentFuel;
    public float fuelConsumedUpdate = .1f;


    void Start()
    {
        rocket = player.GetComponent<Rigidbody>();

        currentFuel = maxFuel;
        
    }

    void FixedUpdate()
    {
        // Use custom gravity scale if rigid body is not already simulating gravity.
        if(!rocket.useGravity)
        {
            Vector3 accelerationGravity = new Vector3(0, 1, 0);
            Debug.Log("Fake Gravity");
            rocket.AddForce(accelerationGravity * gravity * gravityScale, ForceMode.Acceleration);
        }

        //Inputs
        float xAxis = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            ThrustForward();
        }
        Rotation(transform, -xAxis * rotationSpeed);

        
    }


    #region Movement

    //Apply upwards thrust to slow fall
    private void ThrustForward()
    {
        // Consume and check fuel before we thrust
        currentFuel -= fuelConsumedUpdate;

        Debug.Log(currentFuel);     // TEST ONLY

        if(currentFuel < minFuel)
        {
            currentFuel = minFuel;
            return;
        }

        // Add thrust
        Vector3 boost = transform.up * ThrustAmount;
        rocket.AddForce(boost);
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
        if (collision.relativeVelocity.magnitude > 10)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Landing on side
    private void OnTriggerStay (Collider side)
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}