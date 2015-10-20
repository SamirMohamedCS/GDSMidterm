using UnityEngine;
using System.Collections;

public class HarshE : MonoBehaviour
{

    public Transform playerT;
    Rigidbody myRB;
    float speed = .07f;
    bool shouldMove;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        shouldMove = true;
    }

    // Update is called once per frame
    void Update()
    {
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
        
    }

    /*
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
    }*/
}
