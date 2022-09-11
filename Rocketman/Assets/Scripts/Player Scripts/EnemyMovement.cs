using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody enemyBody;
    public float velocity_x;
    public float velocity_y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //move function for enemy left and right
    private void move()
    {
        Vector3 moveDirection = new Vector3(1 * velocity_x, 1 * velocity_y, 0);
        enemyBody.AddForce(moveDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(enemyBody.gameObject);
    }



}

