using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
