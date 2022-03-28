using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] int levelNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelManager.instance.NextLevel(levelNumber));
    }
}
