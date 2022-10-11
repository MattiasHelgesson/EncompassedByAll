using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WindowRepairPanel : MonoBehaviour
{
    [SerializeField]
    Task ownerTask;

    bool gameStarted = false;

    GameObject lastFirstSelectedGameObject;

    //ownerTask.SetAsResolved();
    //Invoke("Hide", 1);

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
