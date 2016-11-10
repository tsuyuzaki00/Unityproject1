using UnityEngine;
using UnityEngine.UI;

public class ScoreParameters : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _scoreText;

    private int Score;

    public void addScore(int Plus)
    {
        _title.text = ((int)_player.PlayerNumber) + "Player";
        Score += Plus;
        _scoreText.GetComponent<Text>().text = Score.ToString();
    }
}
