using UnityEngine;
using System.Collections;

public class CollisionSensor : MonoBehaviour
{
    public GameObject Target { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        Target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        Target = null;
    }
}
