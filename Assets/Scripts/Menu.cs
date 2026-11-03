using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject menu;
    [SerializeField] private Animator mainPanelOpen;
    [SerializeField] private Animator mainPanelClose;
    [SerializeField] private Animator levelsPanelOpen;
    [SerializeField] private Animator levelsPanelClose;
    [SerializeField] private Animator levelsTransition;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject settings;
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("SavedVolume", 1);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
    }
    public void LevelsButton(int levelsNo)
    {
        StartCoroutine(Transition(levelsNo));
    }
    public void BackButton()
    {
        StartCoroutine(Delay(levels, menu));
        levelsPanelClose.Play("LevelsPanelClose");
    }
    public void MenuLevelsButton()
    {
        mainPanelClose.Play("PanelClose");
        StartCoroutine(Delay(menu, levels));
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    IEnumerator Delay(GameObject scene1, GameObject scene2)
    {
        yield return new WaitForSeconds(waitTime);
        scene1.SetActive(false);
        scene2.SetActive(true);
    }
    IEnumerator Transition(int levelsNo)
    {
        levelsTransition.Play("LevelsTransitionAnimation");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelsNo);
    }
    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("SavedVolume",value);
    }

    public void SettingsButton()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void SettingsBackButton()
    {
        settings.SetActive(false);
        menu.SetActive(true);

    }
}
