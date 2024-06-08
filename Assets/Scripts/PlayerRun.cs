using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRun : MonoBehaviour
{
    public SpeedBar speedBar;
    private DefaultRun defaultRun;

    void Start()
    {
        defaultRun = GetComponent<DefaultRun>();
    }

    void Update()
    {
        speedBar.SetSpeed(defaultRun.GetSpeed());
    }
}
