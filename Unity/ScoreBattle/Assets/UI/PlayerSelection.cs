using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {

    [SerializeField]
    private PlayerSelect _playerSelect;
    public PlayerSelect PlayerSelect { get { return _playerSelect; } set {_playerSelect = value;} }

    [SerializeField]
    private  Text _SelectText;
    
	void Update ()
    {
        _SelectText.text = PlayerSelect.ToString();
    }
    
}
