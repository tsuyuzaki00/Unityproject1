using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RankRemoval : MonoBehaviour {

    struct ScoreDate
    {
        public string Name;
        public int Score;

        public ScoreDate(string name, int score)
        {
            Name = name;
            Score = score;
        }
    };

    private List<ScoreDate> ScoreDates = new List<ScoreDate>();

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}

    public void Add(string name, int score) {
        ScoreDates.Add(new ScoreDate(name, score));
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    public void Sort()
    {
        ScoreDates.Sort( (lhs, rhs) => rhs.Score - lhs.Score);
    }

    public string GetName(int index) { return ScoreDates[index].Name; }
    public int GetScore(int index) { return ScoreDates[index].Score; }



}
