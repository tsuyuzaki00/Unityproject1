using UnityEngine;
using System.Collections;

public class Attack_Power : MonoBehaviour {

    [SerializeField]
    private GameObject _playerScore;

    [SerializeField]
    private AudioClip _punchSE;

    private int Puls;
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

    public void Weak()
    {
        Puls = 10;
    }

    public void Strong()
    {
        Puls = 20;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Score")
        {
            Debug.Log("OK");
            _playerScore.GetComponent<Parameters>().addScore(Puls);
            AudioSource.PlayOneShot(_punchSE);
        }
    }
}
