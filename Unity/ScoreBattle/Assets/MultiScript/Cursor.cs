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
        bool A4 = Input.GetKeyDown("joystick " + ((int)_playerNumber) + " button 3");
        bool X2 = Input.GetKeyDown("joystick " + ((int)_playerNumber) + " button 1");
        bool B3 = Input.GetKeyDown("joystick " + ((int)_playerNumber) + " button 2");
        bool Y1 = Input.GetKeyDown("joystick " + ((int)_playerNumber) + " button 0");
        bool R = Input.GetKeyDown("joystick " + ((int)_playerNumber) + " button 5") || Input.GetKeyDown("joystick " + ((int)_playerNumber) + " button 7");
        bool L = Input.GetKey("joystick " + ((int)_playerNumber) + " button 6") || Input.GetKey("joystick " + ((int)_playerNumber) + " button 4");


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

        if (A4)
        {

        }
        if (B3) { }
        if (Y1) { }
        if (X2) { }
        if (L) { }
        if (R) { }
    }
}