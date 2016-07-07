using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float jumpPower = 0f;

    public GameObject Enemy;

    public AudioClip sound01;

    private bool Inputmove = true;
    private int count = 0;

    private Animator _animator;
    private AudioSource _sound1;
    private static readonly int MoveHash = Animator.StringToHash("Move");
    private static readonly int Attack1Hash = Animator.StringToHash("Attack1");
    private static readonly int AvoidanceHash = Animator.StringToHash("Avoidance");
    private static readonly int Attack2Hash = Animator.StringToHash("Attack2");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private float UpMove = 0.05f;
    private float DownMove = -0.05f;

    public bool _jump = true;

    [SerializeField]
    private CollisionSensor _rightHand = null;
    [SerializeField]
    private CollisionSensor _leftLeg = null;

    Rigidbody rg;

    void Start () {
        _animator = GetComponent<Animator>();
        _sound1 = GetComponent<AudioSource>();
    }

    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool Y = Input.GetKeyDown("joystick button 3");
        bool B = Input.GetKeyDown("joystick button 1");
        bool X = Input.GetKeyDown("joystick button 2");
        bool A = Input.GetKeyDown("joystick button 0");
        bool R = Input.GetKeyDown("joystick button 5");
        bool L = Input.GetKeyDown("joystick button 6");

        Inputmove = false;
        if (v < -0.2) {
            transform.Translate(0, 0, UpMove, Space.World);
            Inputmove = true;
        } else if (v > 0.2) {
            transform.Translate(0, 0, DownMove, Space.World);
            Inputmove = true;
        } if (h < -0.2) {
            transform.Translate(DownMove, 0, 0, Space.World);
            Inputmove = true;
        } else if (h > 0.2) {
            transform.Translate(UpMove, 0, 0, Space.World);
            Inputmove = true;
        }

        if (Inputmove) {
            transform.LookAt(new Vector3(h, 0, -v) + (transform.position));
        }

        _animator.SetBool(MoveHash, Inputmove);
        _animator.SetBool(Attack1Hash, Y);
        _animator.SetBool(AvoidanceHash, B);
        _animator.SetBool(Attack2Hash, X);
        _animator.SetBool(Jump, A);

        if (B == true)
        {

        }
        
        if (_rightHand.Target != null && Y == true)
        {
            _rightHand.Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 10f, ForceMode.Impulse);
            _sound1.PlayOneShot(sound01);
            _rightHand.Target.GetComponent<Enemy>().DamageCount++;
        }

        if (_leftLeg.Target != null && X == true)
        {
            _leftLeg.Target.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 10f, ForceMode.Impulse);
            Debug.Log(_leftLeg.Target);
            _leftLeg.Target.GetComponent<Enemy>().DamageCount++;
        }

        if (A == true && _jump == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            _jump = false;
        }

    }
    


}
