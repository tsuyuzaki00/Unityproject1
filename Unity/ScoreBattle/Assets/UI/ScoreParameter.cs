using UnityEngine;
using UnityEngine.UI;

public class ScoreParameter : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Text _playerText;

    [SerializeField]
    private Text _scoreText;

    public Player Player
    {
        get { return _player; }
    }

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            _scoreText.text = _score.ToString();
        }
    }
    private int _score;
}
