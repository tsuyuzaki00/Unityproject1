using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float speed;
    private Transform _player;

    void Awake()
    {
        _player = GameObject.Find("hito").transform;
    }

    void Start() {
        speed = 1;
    }

    void Update() {

        Vector3 target = _player.transform.position;
        target.y = 1f;
        transform.LookAt(target);
        Vector3 move = Vector3.forward;
        transform.Translate(move * speed * Time.deltaTime);
 }
}
