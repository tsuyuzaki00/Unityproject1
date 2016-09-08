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
    private Text _lifeText;

    [SerializeField]
    private Image _lifeBar;

    public void Update()
    {
        _title.text = ((int)_player.PlayerNumber) + "Player";
        _lifeText.text = _player.Life + "/" + _player.MaxLife;

        RectTransform textRect = _lifeBar.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(_player.Life, 23.0f);
    }
}
