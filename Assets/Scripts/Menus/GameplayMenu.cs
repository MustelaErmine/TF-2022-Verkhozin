using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] Image pausePanel, lawsPanel;
    [SerializeField] Button continueBtn;

    bool initialized = false;

    private void Start()
    {
        pausePanel = transform.GetChild(2).GetComponent<Image>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPause();
        }
        if (!initialized)
        {
            initialized = true;

            Law[] allLaws = LawsController.instance.inScene.ToArray();

            Transform first = lawsPanel.transform.GetChild(1);

            void ConfigureLaw(Transform where, Law law)
            {
                where.GetComponentInChildren<Text>().text = law.ToString();
                Toggle toggle = where.GetComponent<Toggle>();
                toggle.isOn = LawsController.instance.enabledLaws.Contains(law);
                toggle.onValueChanged.AddListener((bool on) => {
                    if (on)
                        LawsController.instance.EnableLaw(law);
                    else
                        LawsController.instance.DisableLaw(law);

                    continueBtn.interactable = LawsController.instance.CanContinue;
                });
            }

            ConfigureLaw(first, allLaws[0]);

            for (int i = 1; i < allLaws.Length; i++)
            {
                GameObject g = Instantiate(first.gameObject, lawsPanel.transform);
                ConfigureLaw(g.transform, allLaws[i]);
            }
        }
    }

    public void OpenPause()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
