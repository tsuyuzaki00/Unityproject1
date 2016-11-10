using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultParameters : MonoBehaviour
{
    [SerializeField]
    private Text[] RankTexts;


	void Start () {
        var scoreDate = GameObject.Find("ScoreDate").GetComponent<RankRemoval>();
        RankTexts[0].text = scoreDate.GetName(0);



        scoreDate.Destroy();
    }
	
	void Update ()
    {
        //RankTexts[0].text = "1位";
        RankTexts[1].text = "2位";
        RankTexts[2].text = "3位";
        RankTexts[3].text = "4位";

    }
}
