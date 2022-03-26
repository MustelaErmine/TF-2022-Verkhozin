using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button left, right;
    [SerializeField] Image[] levelButtons;

    int startIndex = 0;
    const int buttonsOnScreen = 5;
    void Start()
    {
        UpdateButtons();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SwipeList(int by)
    {
        startIndex += by;
    }
    
    void UpdateButtons()
    {

    }
}
