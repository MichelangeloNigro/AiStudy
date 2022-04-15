using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerTopDown : PlayerMovement
{
    private Player player;
    public void Start()
    { 
        base.Start();
        player = ReInput.players.GetPlayer(0);
        player.AddInputEventDelegate(Movex, UpdateLoopType.Update, InputActionEventType.Update, RewiredConsts.Action.MoveX);
        player.AddInputEventDelegate(Movey, UpdateLoopType.Update, InputActionEventType.Update, RewiredConsts.Action.MoveY);
    }

    private void Update()
    {
        x = -player.GetAxis(RewiredConsts.Action.MoveX);
        y = player.GetAxis(RewiredConsts.Action.MoveY);
    }
    
}
