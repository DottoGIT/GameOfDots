using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TourManager : MonoBehaviour
{
    public static Queue<Player> playersQueue = new Queue<Player>();
    public Player Player1;
    public Player Player2;
    public Player Player3;
    public Player Player4;
    public ScoreBoard scoreBoard;


    private void Awake()
    {
        ///// BETA PLAYER ADD /////
        playersQueue.Enqueue(Player1);
        playersQueue.Enqueue(Player2);
        playersQueue.Enqueue(Player3);
        playersQueue.Enqueue(Player4);
        ///////////////////////////
    }

    public void SetNextTour()
    {
        ChangeToNextPlayer();
        scoreBoard.RearrangeQueue();
    }

    public void ChangeToNextPlayer()
    {
        Player plr = playersQueue.Dequeue();
        playersQueue.Enqueue(plr);
    }

}
