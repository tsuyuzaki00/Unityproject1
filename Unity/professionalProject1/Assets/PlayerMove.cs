using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private bool Inputmove = true;

    private float UpMove = 0.05f;
    private float DownMove = -0.05f;

    void Start () {
	
	}
	
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Inputmove = false;
        if (v < -0.2)
        {
            transform.Translate(0, 0, UpMove, Space.World);
            Inputmove = true;
        }
        else if (v > 0.2)
        {
            transform.Translate(0, 0, DownMove, Space.World);
            Inputmove = true;
        }
        if (h < -0.2)
        {
            transform.Translate(DownMove, 0, 0, Space.World);
            Inputmove = true;
        }
        else if (h > 0.2)
        {
            transform.Translate(UpMove, 0, 0, Space.World);
            Inputmove = true;
        }

        if (Inputmove)
        {
            transform.LookAt(new Vector3(h, 0, -v) + (transform.position));
        }
    }
}
