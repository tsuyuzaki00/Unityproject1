using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parameters : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _scoreText;

    public void Update()
    {
        _title.text = ((int)_player.PlayerNumber) + "Player";
        _scoreText.text += 10;
    }
}
