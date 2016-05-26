using UnityEngine;
using System.Collections;

public class acres : MonoBehaviour
{

    public GameObject Enemy;

    void Update()
    {
        {
            Instantiate(Enemy, new Vector3(Random.Range(3, -3), 5, Random.Range(3, 0)), Quaternion.identity);
        }
    }
}
