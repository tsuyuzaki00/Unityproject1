using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour{
    [SerializeField]
    private GameObject _Enemy;


    void Start () {
	for (int i = 0; i < 10; i++)
        {
            Instantiate(_Enemy, new Vector3(Random.Range(-10,10), 1, Random.Range(-10, 10)), Quaternion.identity);
        }
	}
	
	void Update () {
        
	}
}
