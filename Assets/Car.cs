using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{

    float speed = 2.6f;
    bool respawnIn10 = false;
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(0f, 0f, speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Car hit player");
            other.GetComponent<PlayerScript>().Respawn();
        }
    }
}
