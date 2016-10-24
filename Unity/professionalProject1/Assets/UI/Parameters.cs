using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _scoreText;

    private int Score;

    public void addScore(int s)
    {
        _title.text = ((int)_player.PlayerNumber) + "Player";
        Score += s;
        _scoreText.GetComponent<Text>().text = Score.ToString();
    }
}
