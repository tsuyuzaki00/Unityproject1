using UnityEngine;
using System.Collections;

public class BodySensor : MonoBehaviour {

    [SerializeField]
    private Player player;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Floor"){
            player._jump = true;
        }
    }
}
