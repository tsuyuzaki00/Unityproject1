using UnityEngine;
using UnityEngine.UI;

public class ScoreParameters : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Text _playerText;

    [SerializeField]
    private Text _scoreText;

    private int Score;

    public int GetScore() { return Score; }

    public void addScore(int Plus)
    {
        _playerText.text = ((int)_player.PlayerNumber) + "Player";
        Score += Plus;
        _scoreText.GetComponent<Text>().text = Score.ToString();
    }
}
