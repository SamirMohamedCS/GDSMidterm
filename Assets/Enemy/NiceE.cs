using UnityEngine;
using System.Collections;

public class NiceE : MonoBehaviour {

    public Transform playerT;
    float stopDist = 4f;
    float speed = .03f;
    float minX = -17f;
    float maxX = 17f;
    bool movingRight = true;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        float dist = Vector3.Distance(transform.position, playerT.position);
        if (dist > stopDist)
        {
            MoveBackAndForth();
        }
	}

    void MoveBackAndForth()
    {
        if(movingRight)
        {
            if(transform.position.x > maxX)
            {
                movingRight = false;
            }
            else
            {
                transform.Translate(speed, 0f, 0f);
            }
        }
        else
        {
            if(transform.position.x < minX)
            {
                movingRight = true;
            }
            else
            {
                transform.Translate(-speed, 0f, 0f);
            }
        }
    }
}
