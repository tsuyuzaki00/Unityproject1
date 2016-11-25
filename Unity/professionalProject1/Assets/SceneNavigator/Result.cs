using UnityEngine;
using System.Collections;

public class Result : MonoBehaviour {

    [SerializeField]
    private SceneNavigator _scneeNavigator;

    [SerializeField]
    private PlayerNumber _playerNumber;
    public PlayerNumber PlayerNumber { get { return _playerNumber; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool A4 = Input.GetKeyDown("return");
        if (A4)
        {
            _scneeNavigator.Navigate(Scenes.Title);
        }
    }
}
