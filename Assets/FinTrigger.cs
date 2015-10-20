


using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FinTrigger : MonoBehaviour {

	public Text finText;

    void Start()
    {
        finText.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            finText.enabled = true;
        }
    }
}
