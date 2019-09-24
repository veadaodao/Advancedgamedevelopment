using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Subject
{
    public int level = 1;
    public Observer displayLevel;

    private void Start()
    {
        registerObserver(displayLevel);
    }


    public void updateLevel(int life)
    {
        level += life;
        Notify(level, NotificationType.LevelUpdated);
    }
}
