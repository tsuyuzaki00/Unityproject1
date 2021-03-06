﻿using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField]
    private SceneNavigator _scneeNavigator;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float timer = 120;

    [SerializeField]
     private Text TimerText;

    [SerializeField]
    private GameObject scoreDatePrefab;

    [SerializeField]
    private ScoreParameters[] _scoreParameters;

    [SerializeField]
    private AudioClip _countSound = null;

    [SerializeField]
    private AudioClip _countdownSound = null;

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

    private bool OneAudio = false;
    private float count;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        TimerText.text = timer.ToString("N2");
        if (timer == 60)
        {
            AudioSource.PlayOneShot(_countSound);
        }

        count = timer % 10;

        if (count <= 5 && count >= 4.5)
        {
            Instantiate(prefab, new Vector3(Random.Range(-7.0f, 7.0f), 5, Random.Range(-5.0f, 3.0f)), Quaternion.identity);
        }

        if (timer <= 10)
        {
            Instantiate(prefab, new Vector3(Random.Range(-7.0f, 7.0f), 7, Random.Range(-5.0f, 3.0f)), Quaternion.identity);
            if (OneAudio == false)
            {
                OneAudio = true;
                AudioShot();
            }
        }

        bool Enter = Input.GetKeyDown("return");
        if (timer <= 0.01 || Enter)
        {
            _scoreParameters[0].GetScore();

            var scoreDate =Instantiate(scoreDatePrefab).GetComponent<RankRemoval>();
            scoreDate.gameObject.name = "ScoreDate";
            scoreDate.Add("1Player", _scoreParameters[0].GetScore());
            scoreDate.Add("2Player", _scoreParameters[1].GetScore());
            scoreDate.Add("3Player", _scoreParameters[2].GetScore());
            scoreDate.Add("4Player", _scoreParameters[3].GetScore());
            scoreDate.Sort();
            _scneeNavigator.Navigate(Scenes.Result);
        }
    }

    void AudioShot()
    {
        AudioSource.PlayOneShot(_countdownSound);
    }
}
