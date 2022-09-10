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
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}

//Progressive momentum
//
