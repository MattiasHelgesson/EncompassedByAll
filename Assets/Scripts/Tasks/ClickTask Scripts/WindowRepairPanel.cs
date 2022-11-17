using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class WindowRepairPanel : MonoBehaviour, IDragHandler
{
    [SerializeField]
    Task ownerTask;

    [SerializeField]
    Button WindowCrackedObject;
    [SerializeField]
    Button WindowUncrackedObject;

    //Drag Funktion
    public GameObject movedObject;


    public GameObject blackAround;

    public GameObject uncrackedWindow;

    public Animator WindowAnimat;
    public Animator UncrackAnimat;

    int clickCounter = 0;

    bool clicked = false;

    GameObject lastFirstSelectedGameObject;

    bool blackAllAround = true;

    bool gameStarted = false;

    bool changeSize = false;

    bool windowScale = false;

    bool overlapping = false;

    bool animator = false;

    //ownerTask.SetAsResolved();
    //Invoke("Hide", 1);

    private void Start()
    {

        WindowCrackedObject.onClick.AddListener(WindowCracked);
        Debug.Log("Listeners added");
        WindowUncrackedObject.onClick.AddListener(WindowUnCracked);
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(animator == true)
        {
            Debug.Log("OnDrag");
            Vector2 plannedRectPos = movedObject.GetComponent<RectTransform>().anchoredPosition + eventData.delta;
            movedObject.GetComponent<RectTransform>().anchoredPosition = plannedRectPos;
        }
    }

    void WindowCracked()
    {
        //Scale Window
        Debug.Log("ChangeSize");

        // Debug.Log("knappskit");
        // if (blackAllAround == true)
        // {
        //     WindowAnimat.SetBool("ChangeSize",true);
        //     changeSize = true;
        // }
        //4 if(changeSize == true)
        clickCounter++;
        if (clickCounter == 1)
        {
            WindowAnimat.SetBool("ChangeWindButton", true);
        }
        else if (clickCounter == 2)
        {
            //Move Window
            clicked = false;
            Debug.Log("Flytta");

            WindowAnimat.SetBool("IfChangeWindButtonTrue", true);
            animator = true;
        }
    }
    void WindowUnCracked()
    {
        RectTransform area = blackAround.GetComponent<RectTransform>();
        area.localPosition = new Vector3(area.localPosition.x, area.localPosition.y, 0);
        RectTransform WindowArea = uncrackedWindow.GetComponent<RectTransform>();
        Vector2 windowAreaMin = new Vector2(WindowArea.position.x - (WindowArea.rect.width * WindowArea.localScale.x) / 2, WindowArea.position.y - (WindowArea.rect.height * WindowArea.localScale.y) / 2);
        Vector2 windowAreaMax = new Vector2(WindowArea.position.x + (WindowArea.rect.width * WindowArea.localScale.x) / 2, WindowArea.position.y + (WindowArea.rect.height * WindowArea.localScale.y) / 2);
        Vector2 areaMin = new Vector2(area.position.x - area.rect.width / 2, area.position.y - area.rect.height / 2);
        Vector2 areaMax = new Vector2(area.position.x + area.rect.width / 2, area.position.y + area.rect.height / 2);
        WindowArea.localPosition = new Vector3(WindowArea.localPosition.x, WindowArea.localPosition.y, 0);

        Debug.LogFormat("Window Min: {0}, Window Max: {1}", windowAreaMin, windowAreaMax);
        Debug.LogFormat("AREA Min: {0}, Area Max: {1}", areaMin, areaMax);

        if (windowAreaMax.x > areaMax.x && windowAreaMax.y > areaMax.y && windowAreaMin.x < areaMin.x && windowAreaMin.y < areaMin.y)
        {
            Debug.Log("ANIMATOR ACTIVATED!");
            UncrackAnimat.gameObject.GetComponent<Animator>();
            UncrackAnimat.GetComponent<Animator>().enabled = true;
            UncrackAnimat.SetBool("Overlapping", true);
            overlapping = true;
            if (overlapping == true)
            {
                UncrackAnimat.SetBool("SnapPoint", true);
                animator = false;
            }
            
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
