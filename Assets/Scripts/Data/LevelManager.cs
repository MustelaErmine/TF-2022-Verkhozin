using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public Scene[] levels;

    public static LevelManager instance;

    public void Awake()
    {
        instance = this;
    }
    
    public Scene NextLevel(Scene thisScene)
    {
        int index = levels.ToList().IndexOf(thisScene);
        if (index == levels.Length - 1)
            return SceneManager.GetSceneByName("MainMenu");
        return levels[index + 1];
    }
}
