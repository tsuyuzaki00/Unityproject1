using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float speed;
    private Transform _player;
    private int _damageCount;
    public int DamageCount
    {
        set
        {
            isDied();
            _damageCount += value;
        }get
        {
            return _damageCount;
        }
    }

    private void isDied()
    {
        if (DamageCount >= 3)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        _player = GameObject.Find("hito").transform;
        DamageCount = 0;
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
