using UnityEngine;
using System.Collections;

public class PlayerScript3 : MonoBehaviour
{

    //public static Transform playerTransform;
    const float START_SPEED_MULTIPLIER = 10.0f, START_ROTATION_MULTIPLIER = 5.0f;
    Rigidbody playerRB;
    public Transform cameraT, goalT;
    Vector3 oldPosition;
    Vector2 mouseInput;
    Vector3 kbInput;
    public Transform defaultSpawnLoc, carSpawnLoc, spawnLoc2;
    float speedMultiplier, rotationMultiplier;
    float distanceToGoal;
    bool isJumping;
    public GameObject NiceE, HarshE, Car;
    float minX = -9f, maxX = 8f;
    float frame = 0, frame2 = 0;
    float minMass = .8f, maxMass = 1.4f;
    bool useSecondSpawn = false;
    public Light l1, l2, l3;

    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        speedMultiplier = START_SPEED_MULTIPLIER;
        rotationMultiplier = START_ROTATION_MULTIPLIER;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        UpdateInputVectors();

        oldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        UpdateDistanceToGoal();
        

        UpdateIsJumping();
        //if(distanceToGoal > x)
        MoveWithStandardControls();
        CameraStandardFollow(oldPosition);
        //else if distanceToGoal > y
        //MoveWithTankControls
        //Debug.Log(distanceToGoal);
        float spawnMultiplier = distanceToGoal / 100;
        Debug.Log(spawnMultiplier);
        if (spawnMultiplier < 2)
        {
            spawnMultiplier = 2;
        }
        if (frame >= 40 * spawnMultiplier)
        {
            SpawnEnemy();
            Debug.Log("Spawning Enemey");
            frame = 0;
        }
        if (frame2 > 300 + frame)
        {
            frame2 = 0;
            SpawnCar();
        }
        frame++;
        frame2++;
    }

    void UpdateLights()
    {
        float lerpTime = distanceToGoal / 500;
        l1.intensity = Mathf.Lerp(1, 0, lerpTime);
        l2.intensity = Mathf.Lerp(0, 1, lerpTime);
        l3.intensity = Mathf.Lerp(0, .6f, lerpTime);
    }

    void SpawnEnemy()
    {
        float randX = Random.Range(minX, maxX);
        Vector3 spawnLoc = new Vector3(randX, defaultSpawnLoc.position.y, defaultSpawnLoc.position.z);
        float randMass = Random.Range(minMass, maxMass);
        float randEType = Random.value;
        if (distanceToGoal / 500 > randEType)
        {
            GameObject newE = (GameObject)Instantiate(NiceE, spawnLoc, Quaternion.identity);
            //newE.GetComponent<NiceE>().SetMass(randMass);
        }
        else
        {
            GameObject newE = (GameObject)Instantiate(HarshE, spawnLoc, Quaternion.identity);
            //newE.GetComponent<HarshE>().SetMass(randMass);
        }
        //Instantiate(NiceE, spawnLoc, Quaternion.identity);
    }
    public void ToggleSpawn2()
    {
        useSecondSpawn = !useSecondSpawn;
    }

    void SpawnCar()
    {
        Vector3 spawnLoc = carSpawnLoc.position;
        NiceE newE = (NiceE)Instantiate(Car, spawnLoc, Quaternion.identity);
    }



    void MoveWithStandardControls()
    {
        kbInput *= speedMultiplier;
        mouseInput.x *= rotationMultiplier;
        if (isJumping)
        {
            //Debug.Log("Jumping");
            playerRB.velocity = transform.TransformDirection(kbInput.x, playerRB.velocity.y, kbInput.z);
        }
        else
        {
            //Debug.Log("Not Jumping");
            playerRB.velocity = transform.TransformDirection(kbInput);
            //playerRB.velocity = kbInput;
        }
        //transform.Rotate(0f, mouseInput.x, 0f); // turn left or right
        //cameraT.RotateAround(transform.position, Vector3.up, mouseInput.x);
        //cameraT.Rotate(-mouseInput.y, 0f, 0f);
    }

    void CameraStandardFollow(Vector3 prevPos)
    {
        /*/Debug.Log(transform.position + "   " + prevPos)
        Vector3 moveVector = transform.position - prevPos;
        if (moveVector.x > 0 || moveVector.y > 0 || moveVector.z > 0)
            Debug.Log(moveVector);
        cameraT.position += moveVector;*/
        cameraT.position = new Vector3(cameraT.position.x, cameraT.position.y, transform.position.z - 2.1f);

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
        //Debug.Log(playerRB.velocity.y);
        if (playerRB.velocity.y < 0.005f && playerRB.velocity.y > -0.005f)
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }
}
