using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField]
    private SceneNavigator _scneeNavigator;

    [SerializeField]
    private float timer = 120;

    [SerializeField]
     private Text TimerText;

    [SerializeField]
    private GameObject scoreDatePrefab;

    [SerializeField]
    private ScoreParameters[] _scoreParameters;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        TimerText.text = timer.ToString("N2");
        if (timer <= 0.01)
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
}
