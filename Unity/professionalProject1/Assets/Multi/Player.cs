using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField]
    private PlayerNumber _playerNumber;

    [SerializeField]
    private float _jumpPower = 0f;

    public GameObject _enemy;

    public AudioClip _punched;

    private bool _inputmove = true;
    private int _count = 0;

    private Animator _animator;
    private static readonly int MoveHash = Animator.StringToHash("Move");
    private static readonly int Attack1Hash = Animator.StringToHash("Attack1");
    private static readonly int AvoidanceHash = Animator.StringToHash("Avoidance");
    private static readonly int Attack2Hash = Animator.StringToHash("Attack2");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private float _upMove = 0.05f;
    private float _downMove = -0.05f;

    public bool _jump = true;

    [SerializeField]
    private CollisionSensor _rightHand = null;
    [SerializeField]
    private CollisionSensor _leftLeg = null;

    Rigidbody _rg;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float H = Input.GetAxis(((int) _playerNumber) + "P_Horizontal");
        float V = Input.GetAxis(((int) _playerNumber) + "P_Vertical");
        bool Y = Input.GetKeyDown("joystick " + ((int) _playerNumber) + " button 3");
        bool B = Input.GetKeyDown("joystick " + ((int) _playerNumber) + " button 1");
        bool X = Input.GetKeyDown("joystick " + ((int) _playerNumber) + " button 2");
        bool A = Input.GetKeyDown("joystick " + ((int) _playerNumber) + " button 0");
        bool R = Input.GetKeyDown("joystick " + ((int) _playerNumber) + " button 5");
        bool L = Input.GetKeyDown("joystick " + ((int) _playerNumber) + " button 6");

        Debug.Log(Input.GetAxis(((int)_playerNumber) + "P_Horizontal"));
        _inputmove = false;
        if (V < -0.2)
        {
            transform.Translate(0, 0, _upMove, Space.World);
            _inputmove = true;
        }
        else if (V > 0.2)
        {
            transform.Translate(0, 0, _downMove, Space.World);
            _inputmove = true;
        }
        if (H < -0.2)
        {
            transform.Translate(_downMove, 0, 0, Space.World);
            _inputmove = true;
        }
        else if (H > 0.2)
        {
            transform.Translate(_upMove, 0, 0, Space.World);
            _inputmove = true;
        }

        if (_inputmove)
        {
            transform.LookAt(new Vector3(H, 0, -V) + (transform.position));
        }

        _animator.SetBool(MoveHash, _inputmove);
        _animator.SetBool(Attack1Hash, Y);
        _animator.SetBool(AvoidanceHash, B);
        _animator.SetBool(Attack2Hash, X);
        _animator.SetBool(Jump, A);

//        if (B == true)
//        {
//
//        }
//
//        if (_rightHand.Target != null && Y == true)
//        {
//            _rightHand.Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 10f, ForceMode.Impulse);
//            GetComponent<AudioSource>().PlayOneShot(sound01);
//            _rightHand.Target.GetComponent<Enemy>().DamageCount++;
//        }
//
//        if (_leftLeg.Target != null && X == true)
//        {
//            _leftLeg.Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 10f, ForceMode.Impulse);
//            Debug.Log(_leftLeg.Target);
//            _leftLeg.Target.GetComponent<Enemy>().DamageCount++;
//        }
//
//        if (A == true && _jump == true)
//        {
//            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
//            _jump = false;
//        }
    }
}