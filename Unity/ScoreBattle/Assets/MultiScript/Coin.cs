using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private int _score;

    public int Score { get { return _score; } }

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-500.0f, 500.0f), 2, Random.Range(-500.0f, 500.0f));
    }

}
