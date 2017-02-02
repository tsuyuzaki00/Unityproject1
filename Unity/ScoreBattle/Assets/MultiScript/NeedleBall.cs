using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleBall : MonoBehaviour {

    [SerializeField]
    private ScoreParameter[] _scoreParameters;

    void Start () {

    }

    private Player GetTopPlayer()
    {
        var topScore = _scoreParameters[0];
        foreach (var scoreParameter in _scoreParameters)
        {
            if (scoreParameter.Score >= topScore.Score) {topScore = scoreParameter;}
        }
        return topScore.Player;

    }

	void Update () {
        var topPlayter = GetTopPlayer();
        //Debug.Log("TopPlayer: " + topPlayter.PlayerNumber);
        transform.Rotate(0,0,5);
        transform.LookAt(topPlayter.transform.position);
        transform.position += transform.forward * Time.deltaTime * 2;
        //transform.position = topPlayter.transform.position;
    }
}
