using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public int[] levels;

    public static LevelManager instance;

    public void Awake()
    {
        instance = this;
    }
    
    public int NextLevel(int thisScene)
    {
        int index = levels.ToList().IndexOf(thisScene);
        if (index == levels.Length - 1)
            return 0;
        return levels[index + 1];
    }
    public void EnterNextLevel(int thisScene)
    {
        int to = NextLevel(thisScene);
        Save.Instance.lastLevel = Mathf.Max(to - 1, Save.Instance.lastLevel);
        Save.Keep();
        SceneManager.LoadScene(to);
    }
}
