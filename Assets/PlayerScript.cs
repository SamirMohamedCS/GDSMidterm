using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    const float beginningMultipler = 5.0f;
    Rigidbody playerRB, cameraRB, goalRB;
    Vector2 mouseInput;
    Vector3 kbInput;
    float speedMultiplier;
    float distanceToGoal;
    bool isJumping;

	// Use this for initialization
	void Start () 
    {
        playerRB = GetComponent<Rigidbody>();
        UpdateMultiplier(beginningMultipler);
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateInputVectors();
        UpdateIsJumping();

	}
    
    void FixedUpdate()
    {
        UpdateDistanceToGoal();
        //if(distanceToGoal > x)
        MoveWithStandardControls();
        //else if distanceToGoal > y
        //MoveWithTankControls
        
    }


    void MoveWithStandardControls()
    {
        //playerRB
    }

    void MoveWithTankControls()
    {

    }

    void UpdateInputVectors()
    {
        float jump = Input.GetButton("Jump") ? 1f : 0f;
        kbInput = new Vector3(Input.GetAxis("Horizontal"), jump, Input.GetAxis("Vertical"));
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

   void UpdateMultiplier(float newMultiplier)
    {
        speedMultiplier = newMultiplier;
    }

    void UpdateDistanceToGoal()
    {
       distanceToGoal = Vector3.Distance(playerRB.position, cameraRB.position);
    }

    void UpdateIsJumping()
    {
        if (playerRB.velocity.y < 0.005f && playerRB.velocity.y > -0.005f)
            isJumping = false;
        else
            isJumping = true;
    }
}
