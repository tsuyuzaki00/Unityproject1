using UnityEngine;
using System.Collections;

public class AttackSensor : MonoBehaviour {

    [SerializeField]
    private Player _player = null;

    /// <summary>
    /// このセンサーが当たる対象のゲームオブジェクトの一覧。
    /// null または空配列の場合はフィルターしない。
    /// </summary>
    [SerializeField]
    private GameObject[] _gameObjects = null;

    void OnTriggerEnter(Collider c)
    {
        if (_gameObjects == null || _gameObjects.Length == 0)
        {
            _player.Attack(this, c.gameObject);
            return;
        }

        foreach(var obj in _gameObjects)
        {
            if (c.gameObject == obj)
            {
                _player.Attack(this, c.gameObject);
                break;
            }
        }
    }
}
