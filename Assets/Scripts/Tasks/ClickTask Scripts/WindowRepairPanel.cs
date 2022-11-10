using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class WindowRepairPanel : MonoBehaviour
{
    [SerializeField]
    Task ownerTask;

    [SerializeField]
    Button WindowCracked;

    public GameObject movedObject;

    public Animator WindowAnimat;

    GameObject lastFirstSelectedGameObject;

    bool blackAllAround = true;

    bool gameStarted = false;

    bool changeSize = false;

    bool WindowScale = false;

    //ownerTask.SetAsResolved();
    //Invoke("Hide", 1);

    private void Start()
    {
        WindowCracked.onClick.AddListener(WindowCrackedScale);
        WindowCracked.onClick.AddListener(WindowCrackedMove);
        Debug.Log("Listeners added");
        WindowDrag();
    }


    void WindowDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D UncrackedWindow = Physics2D.OverlapPoint(mousePosition);
            if (UncrackedWindow)
            {
                movedObject = UncrackedWindow.transform.gameObject;
            }
        }
        
        
    }
    void WindowCrackedScale()
    {
        Debug.Log("ChangeSize");

        // Debug.Log("knappskit");
        // if (blackAllAround == true)
        // {
        //     WindowAnimat.SetBool("ChangeSize",true);
        //     changeSize = true;
        // }
        //4 if(changeSize == true)

        WindowAnimat.SetBool("ChangeWindButton", true);
        WindowScale = true;
    }
    void WindowCrackedMove()
    {
        Debug.Log("Flytta");

        if (WindowScale == true)
        {
            WindowAnimat.SetBool("IfChangeWindButtonTrue", true);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        lastFirstSelectedGameObject = GameManager.Instance.EventSystem.firstSelectedGameObject;
        GameManager.Instance.EventSystem.firstSelectedGameObject = gameObject;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        GameManager.Instance.EventSystem.firstSelectedGameObject = lastFirstSelectedGameObject;
    }
}
