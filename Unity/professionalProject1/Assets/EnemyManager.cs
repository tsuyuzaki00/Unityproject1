using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour{
    [SerializeField]
    private GameObject _Enemy;

    [SerializeField]
    private int _EnemyNum;

    void Start () {
	for (int i = 0; i < _EnemyNum; i++)
        {
            Instantiate(_Enemy, new Vector3(Random.Range(-10,10), 1.5f, Random.Range(-10, 10)), Quaternion.identity);
        }
	}
	
	void Update () {
        
	}
}
