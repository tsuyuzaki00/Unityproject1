using UnityEngine;

public class AttackSensor : MonoBehaviour {

    [SerializeField]
    private Player _player = null;

    void OnTriggerEnter(Collider c)
    {
        var other = c.gameObject.GetComponent<Player>();
        if (other != null)
        {
            _player.Attack(this, other);
        }
    }
}
