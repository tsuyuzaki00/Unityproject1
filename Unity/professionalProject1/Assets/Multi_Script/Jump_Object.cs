using UnityEngine;
using System.Collections;

public class Jump_Object : MonoBehaviour

{
    [SerializeField]
    private Player player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Floor")
        {
            //player. = true;
        }
    }
}
