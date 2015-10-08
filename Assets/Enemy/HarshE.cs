using UnityEngine;
using System.Collections;

public class HarshE : MonoBehaviour
{

    public Transform playerT;
    Rigidbody myRB;
    float speed = .03f;
    float minX = -17f;
    float maxX = 17f;
    bool movingRight, shouldMove;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        shouldMove = true;
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ShouldMove: " + shouldMove + "   MovingRight: " + movingRight);
        //float dist = Vector3.Distance(transform.position, playerT.position);
        if (shouldMove)
        {
            MoveBackAndForth();
        }
    }

    void MoveBackAndForth()
    {
        if (movingRight)
        {
            if (transform.position.x >= maxX)
            {
                movingRight = false;
            }
            else
            {
                transform.Translate(speed, 0f, 0f);
                //myRB.velocity = transform.TransformDirection(speed, 0f, 0f);
            }
        }
        else
        {
            if (transform.position.x < minX)
            {
                movingRight = true;
            }
            else
            {
                transform.Translate(-speed, 0f, 0f);
                //myRB.velocity = transform.TransformDirection(-speed, 0f, 0f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            shouldMove = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            shouldMove = true;
        }
    }
}
