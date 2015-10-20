using UnityEngine;
using System.Collections;

public class NiceE : MonoBehaviour {

    //public Transform playerT;
    Rigidbody myRB;
    float speed = .07f;
    bool shouldMove;

	// Use this for initialization
	void Start () 
    {
        myRB = GetComponent<Rigidbody>();
        shouldMove = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log("ShouldMove: " + shouldMove + "   MovingRight: " + movingRight);
        //float dist = Vector3.Distance(transform.position, playerT.position);
        if (shouldMove)
        {
            MoveBackAndForth();
        }
	}

    public void SetPosition(Vector3 inPosition)
    {
        transform.position = inPosition;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetMass(float newMass)
    {
        myRB.mass = newMass;
    }

    void MoveBackAndForth()
    {
        transform.Translate(0f, 0f, -speed);
        /*if(movingRight)
        {
            if(transform.position.x >= maxX)
            {
                //movingRight = false;
                //transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.Translate(speed, 0f, 0f);
                //myRB.velocity = transform.TransformDirection(speed, 0f, 0f);
            }
        }
        else
        {
            if(transform.position.x < minX)
            {
                //movingRight = true;
            }
            else
            {
                transform.Translate(-speed, 0f, 0f);
                //myRB.velocity = transform.TransformDirection(-speed, 0f, 0f);
            }
        } */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            shouldMove = false;
        } 
        else if (other.tag == "respawnE")
        {
            
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
