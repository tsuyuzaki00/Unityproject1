using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool Inputmove = true;
    public Animator HumanAnimator;

    // Use this for initialization
    void Start () {
        HumanAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool fire = Input.GetButtonDown("Fire1");

        if (fire){
            HumanAnimator.Play("Attack1");
            Debug.Log("1ボタン");
        }
		Inputmove = false;
		if(v < -0.2){
			transform.Translate(0,0,0.1f,Space.World);
			Inputmove = true;
		}else if(v > 0.2){
			transform.Translate(0,0,-0.1f,Space.World);
			Inputmove = true;
		}if(h < -0.2){
			transform.Translate(-0.1f,0,0,Space.World);
			Inputmove = true;
		}else if(h > 0.2){
			transform.Translate(0.1f,0,0,Space.World);
			Inputmove = true;
		}if(Inputmove){
		transform.LookAt(new Vector3(Input.GetAxis("Horizontal"),0,-Input.GetAxis("Vertical"))+(transform.position));
		}
        //Debug.Log(transform.forward);

    }

//	void OnCollisionEnter() {
//		GetComponent<Rigidbody>(0,10,0);GetComponent;
//	}
}
