using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsManager : MonoBehaviour
{
    public static Dot[,] DotsArray;
    public static int gridSize;

    public static void ConnectDots(List<Dot> dotsToConnect)
    {
        foreach(var dot in dotsToConnect)
        {
            foreach(var neighbour in dot.GetNeighbours())
            {
                if (dotsToConnect.Contains(neighbour)) dot.connectedDots.Add(neighbour);
            }
            dot.DisplayConnectionToDots();
        }
    }
}
