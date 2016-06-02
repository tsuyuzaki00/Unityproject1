using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public AudioClip sound01;

    private bool Inputmove = true;

    private Animator _animator;
    private static readonly int MoveHash = Animator.StringToHash("Move");
    private static readonly int Attack1Hash = Animator.StringToHash("Attack1");
    private static readonly int AvoidanceHash = Animator.StringToHash("Avoidance");
    private static readonly int Attack2Hash = Animator.StringToHash("Attack2");
    private static readonly int Jump = Animator.StringToHash("Jump");

    [SerializeField]
    private CollisionSensor _rightHand = null;


    void Start () {
        _animator = GetComponent<Animator>();
    }
	
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool fire1 = Input.GetButtonDown("Fire1");
        bool fire2 = Input.GetButtonDown("Fire2");
        bool fire3 = Input.GetButtonDown("Fire3");
        bool jump = Input.GetButtonDown("Jump");

        Inputmove = false;
		if(v < -0.2){
			transform.Translate(0,0,0.05f,Space.World);
			Inputmove = true;
		}else if(v > 0.2){
			transform.Translate(0,0,-0.05f,Space.World);
			Inputmove = true;
		}if(h < -0.2){
			transform.Translate(-0.05f,0,0,Space.World);
			Inputmove = true;
		}else if(h > 0.2){
			transform.Translate(0.05f,0,0,Space.World);
			Inputmove = true;
		}if(Inputmove){
		    transform.LookAt(new Vector3(h,0,-v)+(transform.position));
		}

        _animator.SetBool(MoveHash, Inputmove);
        _animator.SetBool(Attack1Hash, fire1);
        _animator.SetBool(AvoidanceHash, fire2);
        _animator.SetBool(Attack2Hash, fire3);
        _animator.SetBool(Jump, jump);

        if (fire2 == true)
        {
            transform.Translate(0,0,2);
        }

        if (_rightHand.Target != null && fire1 == true)
        {
            _rightHand.Target.GetComponent<Rigidbody>().AddForce(0,5,5, ForceMode.Impulse);
            GetComponent<AudioSource>().PlayOneShot(sound01);
            Debug.Log("Hit");
        }
    }

}
