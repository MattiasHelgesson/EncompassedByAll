using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window_Task : Task
{
    [SerializeField]
    WindowRepairPanel gamePanel;

    protected override void OnStart()
    {

    }

    public override void OnInteract()
    {
       gamePanel.Show();
    }

}

