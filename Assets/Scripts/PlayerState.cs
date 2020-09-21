using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    private static PlayerState _instance;

    public bool IsJump;
    public static PlayerState Instance => _instance ?? (_instance = new PlayerState());


    PlayerState()
    {
        IsJump = false;
    }
}
