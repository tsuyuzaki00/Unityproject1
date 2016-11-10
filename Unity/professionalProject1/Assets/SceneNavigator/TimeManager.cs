using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeManager : MonoBehaviour {

    private float timer = 10;

    Text text;

    void Start()
    {

        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {

        timer -= Time.deltaTime;
        text.text = timer.ToString("N2");
        if (timer <= 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
