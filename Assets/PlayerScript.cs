﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    const float START_SPEED_MULTIPLIER = 10.0f, START_ROTATION_MULTIPLIER = 5.0f;
    Rigidbody playerRB;
    public Transform cameraT, goalT;
    Vector3 oldPosition;
    Vector2 mouseInput;
    Vector3 kbInput;
    float speedMultiplier, rotationMultiplier;
    float distanceToGoal;
    bool isJumping;

	// Use this for initialization
	void Start () 
    {
        playerRB = GetComponent<Rigidbody>();
        speedMultiplier = START_SPEED_MULTIPLIER;
        rotationMultiplier = START_ROTATION_MULTIPLIER;
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateInputVectors();
        UpdateIsJumping();

	}
    
    void FixedUpdate()
    {

        oldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        UpdateDistanceToGoal();
        //if(distanceToGoal > x)
        MoveWithStandardControls();
        CameraStandardFollow(oldPosition);
        //else if distanceToGoal > y
        //MoveWithTankControls
        
    }


    void MoveWithStandardControls()
    {
        kbInput *= speedMultiplier;
        mouseInput.x *= rotationMultiplier;
        if (isJumping)
            playerRB.velocity = transform.TransformDirection(kbInput.x, playerRB.velocity.y, kbInput.z);
        else
            playerRB.velocity = transform.TransformDirection(kbInput);
        transform.Rotate(0f, mouseInput.x, 0f); // turn left or right
        cameraT.RotateAround(transform.position, Vector3.up, mouseInput.x);
        cameraT.Rotate(-mouseInput.y, 0f, 0f);
    }

    void CameraStandardFollow(Vector3 prevPos)
    {
        Debug.Log(transform.position + "   " + prevPos);
        Vector3 moveVector = transform.position - prevPos;
        cameraT.Translate(moveVector);
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
       distanceToGoal = Vector3.Distance(playerRB.position, goalT.position);
    }

    void UpdateIsJumping()
    {
        if (playerRB.velocity.y < 0.005f && playerRB.velocity.y > -0.005f)
            isJumping = false;
        else
            isJumping = true;
    }
}
