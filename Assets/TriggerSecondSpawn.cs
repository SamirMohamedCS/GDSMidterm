using UnityEngine;
using System.Collections;

public class TriggerSecondSpawn : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            other.GetComponent<PlayerScript>().ToggleSpawn2();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" )
        {
            other.GetComponent<PlayerScript>().ToggleSpawn2();
        }
    }
}
