using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Objects")]
    public GameObject upPoint;
    public GameObject downPoint;
    private Vector3 upPos;
    private Vector3 downPos;
    [Header("Variables")]
    public int speed;
    private bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        upPos = upPoint.transform.position;

        downPos = downPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //move function for enemy left and right
    private void move()
    {
        if (goingUp)
        {
            if (transform.position.y >= upPos.y)
            {
                goingUp = false;
            }
            else
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.y <= downPos.y)
            {
                goingUp = true;
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
        }
    }


   
}

