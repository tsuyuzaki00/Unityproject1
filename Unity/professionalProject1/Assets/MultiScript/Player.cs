using UnityEngine;

public class Player : MonoBehaviour
{

    #region 定数
    private static readonly int DamageHash = Animator.StringToHash("Damege");
    private static readonly int MoveHash = Animator.StringToHash("Working");
    private static readonly int PunchingHash = Animator.StringToHash("Punching");
    private static readonly int AvoidanceHash = Animator.StringToHash("Rolling");
    private static readonly int Attack2Hash = Animator.StringToHash("Kicking");
    private static readonly int Jump = Animator.StringToHash("Jump");

    #endregion

    #region SerializeField

    [SerializeField]
    private PlayerNumber _playerNumber;
    public PlayerNumber PlayerNumber { get { return _playerNumber; } }

    [SerializeField]
    public int _score { get; private set; }

    [SerializeField]
    private float _jumpPower = 5f;

    [SerializeField]
    private bool _jump = false;

    [SerializeField]
    private AttackSensor _rightHand;

    [SerializeField]
    private AttackSensor _leftFoot;

    [SerializeField]
    private GameObject _scoreText;

    [SerializeField]
    private AudioClip _attackSound = null;

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

    private bool _inputmove = true;
    private float _upMove = 0.05f;
    private float _downMove = -0.05f;

    [SerializeField]
    private float avoidanceMove = 0.07f;

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



        AnimatorStateInfo stateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.shortNameHash == AvoidanceHash)
        {
            transform.Translate(0, 0, avoidanceMove, Space.Self);
        }
        
        _inputmove = false;
        if (V < -0.5)
        {
            transform.Translate(0, 0, _upMove, Space.World);
            _inputmove = true;
        }
        else if (V > 0.5)
        {
            transform.Translate(0, 0, _downMove, Space.World);
            _inputmove = true;
        }
        if (H < -0.5)
        {
            transform.Translate(_downMove, 0, 0, Space.World);
            _inputmove = true;
        }
        else if (H > 0.5)
        {
            transform.Translate(_upMove, 0, 0, Space.World);
            _inputmove = true;
        }

        if (_inputmove)
        {
            transform.LookAt(new Vector3(H, 0, -V) + (transform.position));
        }

        Animator.SetBool(MoveHash, _inputmove);
        Animator.SetBool(PunchingHash, Y1);
        Animator.SetBool(AvoidanceHash, B3);
        Animator.SetBool(Attack2Hash, X2);
        Animator.SetBool(Jump, A4);

        if (B3){}
        if (Y1){}
        if (X2){}
        if (L){}
        if (R){}

        if (A4)
        {
            Rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }

    public void Attack(AttackSensor sensor, GameObject gameObject)
    {
        var animationState = Animator.GetNextAnimatorStateInfo(0);
        if (animationState.shortNameHash == PunchingHash)
        {
            AudioSource.PlayOneShot(_attackSound);
            _scoreText.GetComponent<ScoreParameters>().addScore(10);
        }

        if (animationState.shortNameHash == Attack2Hash)
        {
            AudioSource.PlayOneShot(_attackSound);
            _scoreText.GetComponent<ScoreParameters>().addScore(20);
        }

    }
}