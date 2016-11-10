using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{

    [SerializeField]
    private SceneNavigator _scneeNavigator;

    private float timer = 3;

    [SerializeField]
     private Text TimerText;

    [SerializeField]
    private GameObject scoreDatePrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        TimerText.text = timer.ToString("N2");
        if (timer <= 0)
        {
            var scoreDate =Instantiate(scoreDatePrefab).GetComponent<RankRemoval>();
            scoreDate.gameObject.name = "ScoreDate";
            scoreDate.Add("1Player",100);
            scoreDate.Add("hogeho", 1100);
            scoreDate.Sort();
            _scneeNavigator.Navigate(Scenes.Result);
        }
    }
}
