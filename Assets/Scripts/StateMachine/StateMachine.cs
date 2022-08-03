using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME,
        RESET_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;
    private StateBase _currentState;
    public Player player;
    public float TimeToStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new statePlaying());
        dictionaryState.Add(States.RESET_POSITION, new stateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateBase());
        dictionaryState.Add(States.RESET_GAME, new stateResetGame());

        SwitchState(States.MENU);
    }

    private void SwitchState(States state)
    {
        if (_currentState != null) _currentState.onStateExit();

        _currentState = dictionaryState[state];

        _currentState.onStateEnter(player);

    }

    private void Update()
    {
        if (_currentState != null) _currentState.onStateStay();


        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchState(States.PLAYING);          
        }
           
        if (Input.GetKeyDown(KeyCode.Space))
             SwitchState(States.RESET_GAME);        
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
