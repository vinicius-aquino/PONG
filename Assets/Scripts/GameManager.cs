using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ball;
    public Player player, player2;
    public static GameManager Instance;
    public float timeToSetBallFree = 1;


    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        ball.CanMove(false);
        ball.resetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    private void SetBallFree()
    {
        ball.CanMove(true);
    }

    public void startGame()
    {
        ball.CanMove(true);
    }

    public void ResetGameOfPlayer()
    {
        player.ResetPlayer();
        player2.ResetPlayer();
    }
}
