using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UISystem : MonoBehaviour
{
    [Header("Main Properties")]
    public UIScreen startScreen;

    [Header("System Events")]
    public UnityEvent onSwitchedScreen = new UnityEvent();

    [Header("Fader Properties")]
    public Image fader;
    public float fadeInDuration = 1f, fadeOutDuration = 1f;

    private Component[] screens = new Component[0];

    private UIScreen previousScreen;
    public UIScreen PreviousScreen { get { return previousScreen; } }


    private UIScreen currentScreen;
    public UIScreen CurrentScreen { get { return currentScreen; } }

    // Start is called before the first frame update
    void Start()
    {
        screens = GetComponentsInChildren<UIScreen>(true);
        InitializeScreens();

        if (startScreen)
        {
            SwitchScreen(startScreen);
        }

        if (fader)
        {
            fader.gameObject.SetActive(true);
        }
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn() 
    {
        if (fader)
        {
            fader.CrossFadeAlpha(0f, fadeInDuration, false);
        }
    }
    public void FadeOut() 
    {
        if (fader)
        {
            fader.CrossFadeAlpha(1f, fadeOutDuration, false);
        }
    }

    public void SwitchScreen(UIScreen aScreen)
    {
        if (aScreen)
        {
            if (currentScreen)
            {
                currentScreen.CloseScreen();
                previousScreen = currentScreen;
            }
            currentScreen = aScreen;
            currentScreen.gameObject.SetActive(true);
            currentScreen.StartScreen();

            if (onSwitchedScreen != null)
            {
                onSwitchedScreen.Invoke();
            }
        }
    }

    public void GoToPreviousScreen()
    {
        if (previousScreen)
        {
            SwitchScreen(previousScreen);
        }
    }

    public void LoadScene(int index)
    {
        StartCoroutine(WaitToLoadScene(index));
    }

    IEnumerator WaitToLoadScene(int index)
    {
        yield return null;
    }

    void InitializeScreens()
    {
        foreach(var screen in screens)
        {
            screen.gameObject.SetActive(true);
        }

    }
}
