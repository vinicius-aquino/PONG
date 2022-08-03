using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
   public virtual void onStateEnter(object o = null)
    {
        Debug.Log("onStateEnter");
    }
    public virtual void onStateStay()
    {
        Debug.Log("onStateStay");
    }
    
    public virtual void onStateExit()
    {
        Debug.Log("onStateExit");
    }
}


public class statePlaying : StateBase
{
    public override void onStateEnter(object o = null)
    {
        base.onStateEnter(o);
        BallBase b = (BallBase)o;

        GameManager.Instance.startGame();
    }
}

public class stateResetPosition : StateBase
{
    public override void onStateEnter(object o = null)
    {
        base.onStateEnter(o);
        GameManager.Instance.ResetBall();
    }
}

public class stateResetGame : StateBase
{
    public override void onStateEnter(object o = null)
    {
        base.onStateEnter(o);
        Player p = (Player)o;

        GameManager.Instance.ResetBall();
        GameManager.Instance.ResetGameOfPlayer();
    }
}
