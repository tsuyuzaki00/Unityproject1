using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool s = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Vertical") < -0.2){
			transform.Translate(0,0,0.1f,Space.World);
			s = true;
		}else if(Input.GetAxis("Vertical") > 0.2){
			transform.Translate(0,0,-0.1f,Space.World);
			s = true;
		}if(Input.GetAxis("Horizontal") < -0.2){
			transform.Translate(-0.1f,0,0,Space.World);
			s = true;
		}else if(Input.GetAxis("Horizontal") > 0.2){
			transform.Translate(0.1f,0,0,Space.World);
			s = true;
		}
		s = true;
		transform.LookAt(new Vector3(Input.GetAxis("Horizontal"),0,-Input.GetAxis("Vertical"))+(transform.position));
		Debug.Log(Input.GetAxis("Vertical"));
		Debug.Log(Input.GetAxis("Horizontal"));
		Debug.Log(transform.forward);
	}
}
