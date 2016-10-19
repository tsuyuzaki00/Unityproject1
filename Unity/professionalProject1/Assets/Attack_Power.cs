using UnityEngine;
using System.Collections;

public class Attack_Power : MonoBehaviour {

    [SerializeField]
    private GameObject _playerScore;

    [SerializeField]
    private AudioClip _punchSE;

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
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Score")
        {
            Debug.Log("OK");
            _playerScore.GetComponent<Parameters>().addScore(10);
            AudioSource.PlayOneShot(_punchSE);
        }
    }
}
