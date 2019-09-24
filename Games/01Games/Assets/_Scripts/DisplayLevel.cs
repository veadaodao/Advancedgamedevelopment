using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DisplayLevel : Observer
{

    public override void OnNotify(object o, NotificationType n)
    {
        if (n == NotificationType.LevelUpdated)
        {
            GetComponent<TextMeshProUGUI>().text = "Piggy:" + o;
        }

    }
}
