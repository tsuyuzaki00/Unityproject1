using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool Inputmove = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Inputmove = false;
		if(Input.GetAxis("Vertical") < -0.2){
			transform.Translate(0,0,0.1f,Space.World);
			Inputmove = true;
		}else if(Input.GetAxis("Vertical") > 0.2){
			transform.Translate(0,0,-0.1f,Space.World);
			Inputmove = true;
		}if(Input.GetAxis("Horizontal") < -0.2){
			transform.Translate(-0.1f,0,0,Space.World);
			Inputmove = true;
		}else if(Input.GetAxis("Horizontal") > 0.2){
			transform.Translate(0.1f,0,0,Space.World);
			Inputmove = true;
		}if(Inputmove){
		transform.LookAt(new Vector3(Input.GetAxis("Horizontal"),0,-Input.GetAxis("Vertical"))+(transform.position));
		}
		Debug.Log(transform.forward);
	}

//	void OnCollisionEnter() {
//		GetComponent<Rigidbody>(0,10,0);GetComponent;
//	}
}
