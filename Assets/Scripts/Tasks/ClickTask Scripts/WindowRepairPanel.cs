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


    public Animator WindowAnimat;

    GameObject lastFirstSelectedGameObject;

    bool blackAllAround = true;

    bool gameStarted = false;

    bool changeSize = false;

    //ownerTask.SetAsResolved();
    //Invoke("Hide", 1);

    private void Start()
    {
        WindowCracked.onClick.AddListener(WindowPressed);
    }

    void WindowPressed()
    {
        Debug.Log("knappskit");
        if (blackAllAround == true)
        {
            WindowAnimat.SetBool("ChangeSize",true);
            changeSize = true;
        }
       //4 if(changeSize == true)
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
