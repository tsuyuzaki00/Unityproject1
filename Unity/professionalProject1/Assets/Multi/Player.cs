using UnityEngine;

public class Player : MonoBehaviour
{
    #region 定数

    private static readonly int MoveHash = Animator.StringToHash("Move");
    private static readonly int Attack1Hash = Animator.StringToHash("Attack1");
    private static readonly int AvoidanceHash = Animator.StringToHash("Avoidance");
    private static readonly int Attack2Hash = Animator.StringToHash("Attack2");
    private static readonly int Jump = Animator.StringToHash("Jump");

    #endregion

    #region SerializeField

    [SerializeField]
    private PlayerNumber _playerNumber;

    [SerializeField]
    private float _jumpPower = 0f;

    [SerializeField]
    private CollisionSensor _rightHand = null;

    [SerializeField]
    private CollisionSensor _leftLeg = null;

    #endregion

    #region Components

    private Animator _animator;
    public Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
            return _animator;
        }
    }

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody
    {
        get
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
            }
            return _rigidbody;
        }
    }

    private AudioSource _audioSource;
    public AudioSource AudioSource
    {
        get
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
            }
            return _audioSource;
        }
    }

    #endregion

    public GameObject _enemy;
    public AudioClip _punched;

    private bool _inputmove = true;
    private int _count = 0;
    private float _upMove = 0.05f;
    private float _downMove = -0.05f;
    public bool _jump = true;

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

        Animator.SetBool(MoveHash, _inputmove);
        Animator.SetBool(Attack1Hash, Y);
        Animator.SetBool(AvoidanceHash, B);
        Animator.SetBool(Attack2Hash, X);
        Animator.SetBool(Jump, A);

        if (B == true)
        {

        }

        if (_rightHand.Target != null && Y == true)
        {
            _rightHand.Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 10f, ForceMode.Impulse);
            AudioSource.PlayOneShot(_punched);
            _rightHand.Target.GetComponent<Enemy>().DamageCount++;
        }

        if (_leftLeg.Target != null && X == true)
        {
            _leftLeg.Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 10f, ForceMode.Impulse);
            _leftLeg.Target.GetComponent<Enemy>().DamageCount++;
        }

        if (A == true && _jump == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _jump = false;
        }
    }
}