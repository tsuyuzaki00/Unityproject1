using UnityEngine;

public class Cursor : MonoBehaviour
{
    #region SerializeField

    [SerializeField]
    private PlayerNumber _playerNumber;
    public PlayerNumber PlayerNumber { get { return _playerNumber; } }

    #endregion

    private float _upMove = 5f;
    private float _downMove = -5f;

    void Start()
    {

    }

    void Update()
    {
        float H = Input.GetAxis(((int)_playerNumber) + "P_Horizontal");
        float V = Input.GetAxis(((int)_playerNumber) + "P_Vertical");

        if (V < -0.5)
        {
            transform.Translate(0,_upMove,0, Space.World);
        }
        else if (V > 0.5)
        {
            transform.Translate(0,_downMove,0, Space.World);
        }
        if (H < -0.5)
        {
            transform.Translate(_downMove, 0, 0, Space.World);
        }
        else if (H > 0.5)
        {
            transform.Translate(_upMove, 0, 0, Space.World);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("aaa");
        var playerSelection = collision.gameObject.GetComponent<PlayerSelection>();
        if (playerSelection != null && Input.GetKeyDown("joystick button 3"))
        {
            playerSelection.PlayerSelect = PlayerSelect.Player;
        }
    }
}