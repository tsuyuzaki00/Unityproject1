using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    Title = 0,
    Battle = 1,
    Result = 2,
    Menu = 3
}

public class SceneNavigator : MonoBehaviour
{
    public Scenes SceneIndex { get { return (Scenes)SceneManager.GetActiveScene().buildIndex; } }

    public void Navigate(Scenes scene)
    {
        //To do 画面切り替え演出をここに書く
        SceneManager.LoadScene((int)scene);
    }
}
