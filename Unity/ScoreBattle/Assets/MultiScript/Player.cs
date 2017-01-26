using UnityEngine;

public class Player : MonoBehaviour
{
    #region 定数

    //private static readonly int DamageHash = Animator.StringToHash("Damege");
    private static readonly int MoveHash = Animator.StringToHash("Working");
    private static readonly int PunchingHash = Animator.StringToHash("Punching");
    private static readonly int AvoidanceHash = Animator.StringToHash("Rolling");
    private static readonly int KickingHash = Animator.StringToHash("Kicking");
    private static readonly int DropkingHash = Animator.StringToHash("Dropkick");
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
    private AttackSensor _rightFoot;

    [SerializeField]
    private ScoreParameters _scoreText;

    [SerializeField]
    private AudioClip _panchSound = null;

    [SerializeField]
    private AudioClip _kickSound = null;

    [SerializeField]
    private AudioClip _dropSound = null;

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

    private Rigidbody rig;

    void Start()
    {
       rig = GetComponent<Rigidbody>();
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
        Animator.SetBool(AvoidanceHash, B3||X2);
        Animator.SetBool(DropkingHash, Y1||A4);
    }

    public void Attack(AttackSensor sensor, Player player)
    {
        var animationState = Animator.GetNextAnimatorStateInfo(0);
        if (animationState.shortNameHash == PunchingHash)
        {
            AudioSource.PlayOneShot(_panchSound);
            _scoreText.addScore(10);
            player.Blow(transform.forward*500);
        }

        if (animationState.shortNameHash == KickingHash)
        {
            AudioSource.PlayOneShot(_kickSound);
            _scoreText.addScore(20);
            player.Blow((player.transform.position-transform.position).normalized*1000);
        }    

        if (animationState.shortNameHash == DropkingHash)
        {
            AudioSource.PlayOneShot(_dropSound);
            _scoreText.addScore(100);
            player.Blow(transform.up * 100);
            player.Blow(transform.forward * 1000);
        }
    }

    public void Blow(Vector3 BlowingPower)
    {
        rig.AddForce(BlowingPower);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var coin = collision.gameObject.GetComponent<Coin>();
        if (coin != null)
        {
            _scoreText.addScore(coin.Score);
            Destroy(coin.gameObject);
        }
    }
}