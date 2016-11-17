using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultParameters : MonoBehaviour
{
    [SerializeField]
    private Text[] RankTexts;


	void Start ()
    {
        var scoreDate = GameObject.Find("ScoreDate").GetComponent<RankRemoval>();
        RankTexts[0].text = "1位:" + scoreDate.GetName(0) + ":Score:" + scoreDate.GetScore(0);
        RankTexts[1].text = "2位:" + scoreDate.GetName(1) + ":Score:" + scoreDate.GetScore(1);
        RankTexts[2].text = "3位:" + scoreDate.GetName(2) + ":Score:" + scoreDate.GetScore(2);
        RankTexts[3].text = "4位:" + scoreDate.GetName(3) + ":Score:" + scoreDate.GetScore(3);

        scoreDate.Destroy();
    }
}
