using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : Observer
{

    public override void OnNotify(object o, NotificationType n)
    {
        if (n == NotificationType.ScoreUpdated)
        {
            GetComponent<TextMeshProUGUI>().text = "Score:" + o;
        }
        
    }
}
