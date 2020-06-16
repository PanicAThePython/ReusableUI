using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]
public class UIScreen : MonoBehaviour
{
    [Header("Main Properties")]
    public Selectable startSelectable;

    

    [Header("Screen Events")]
    public UnityEvent onStartScreen = new UnityEvent();
    public UnityEvent onCloseScreen = new UnityEvent();


    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        if (startSelectable)
        {
            EventSystem.current.SetSelectedGameObject(startSelectable.gameObject);
        }
    }

    void Update()
    {
        
    }

    public virtual void StartScreen()
    {
        if(onStartScreen != null)
        {
            onStartScreen.Invoke();
        }

        HandleAnimator("show");
    }
    public virtual void CloseScreen()
    {
        if (onCloseScreen != null)
        {
            onCloseScreen.Invoke();
        }
        HandleAnimator("hide");
    }

    void HandleAnimator(string aTrigger)
    {
        if (animator)
        {
            animator.SetTrigger(aTrigger);
        }
    }
}
