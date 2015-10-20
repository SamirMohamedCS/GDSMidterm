﻿using UnityEngine;
using System.Collections;

public class TriggerLevel : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel(1);
        }
    }
}
