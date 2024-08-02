using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public Vector2 index;

    SpriteRenderer sprite;
    bool wasClicked = false;
    public List<Dot> connectedDots = new List<Dot>();
    Player myPlayer;

    public GameObject Top_Connection;
    public GameObject Top_Right_Connection;
    public GameObject Right_Connection;
    public GameObject Bottom_Right_Connection;
    public GameObject Bottom_Connection;
    public GameObject Bottom_Left_Connection;
    public GameObject Left_Connection;
    public GameObject Top_Left_Connection;

    TourManager tourManag;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        tourManag = FindObjectOfType<TourManager>();
    }

    public void ConnectIfPossible(List<Dot> clickedDots = null, Dot sender = null, Dot originDot = null)
    {
        List<Dot> myNeighbours = GetNeighbours();

        if (clickedDots == null) clickedDots = new List<Dot>();
        clickedDots.Add(this);

        foreach(var dot in myNeighbours)
        {
            if(dot != sender)
            {
                if (clickedDots.Contains(dot) == false)
                {
                    dot.ConnectIfPossible(clickedDots, this, originDot);
                }
                if (dot == originDot)
                {
                    clickedDots.Add(dot);
                    DotsManager.ConnectDots(clickedDots);
                    return;
                }
            }
        }
    }


    public List<Dot> GetNeighbours()
    {
        List<Dot> neighbours = new List<Dot>();
        //Top
        if (GetDotByOffset(0, 1) != null) neighbours.Add(GetDotByOffset(0, 1));
        //Top-Right
        if (GetDotByOffset(1, 1) != null) neighbours.Add(GetDotByOffset(1, 1));
        //Right
        if (GetDotByOffset(1, 0) != null) neighbours.Add(GetDotByOffset(1, 0));
        //Bottom-Right
        if (GetDotByOffset(1, -1) != null) neighbours.Add(GetDotByOffset(1, -1));
        //Bottom
        if (GetDotByOffset(0, -1) != null) neighbours.Add(GetDotByOffset(0, -1));
        //Bottom-Left
        if (GetDotByOffset(-1, -1) != null) neighbours.Add(GetDotByOffset(-1, -1));
        //Left
        if (GetDotByOffset(-1, 0) != null) neighbours.Add(GetDotByOffset(-1, 0));
        //Top - Left
        if (GetDotByOffset(-1, 1) != null) neighbours.Add(GetDotByOffset(-1, 1));

        return neighbours;
    }

    Dot GetDotByOffset(int x, int y)
    {
        if (index.x + x > 0 && index.x + x < DotsManager.gridSize &&
            index.y + y > 0 && index.y + y < DotsManager.gridSize &&
            DotsManager.DotsArray[(int)index.x + x, (int)index.y + y].wasClicked == true &&
            DotsManager.DotsArray[(int)index.x + x, (int)index.y + y].myPlayer == myPlayer)
        {
            return DotsManager.DotsArray[(int)index.x + x, (int)index.y + y];
        }
        else
        {
            return null;
        }
    }

    public void DisplayConnectionToDots()
    {

        foreach (var dot in connectedDots)
        {
            //Top
            if(dot == GetDotByOffset(0,1))
            {
                Top_Connection.SetActive(true);
                continue;
            }
            //Top-Right
            if (dot == GetDotByOffset(1, 1))
            {
                Top_Right_Connection.SetActive(true);
                continue;
            }
            //Right
            if (dot == GetDotByOffset(1, 0))
            {
                Right_Connection.SetActive(true);
                continue;
            }
            //Bottom-Right
            if (dot == GetDotByOffset(1, -1))
            {
                Bottom_Right_Connection.SetActive(true);
                continue;
            }
            //Bottom
            if (dot == GetDotByOffset(0, -1))
            {
                Bottom_Connection.SetActive(true);
                continue;
            }
            //Bottom-Left
            if (dot == GetDotByOffset(-1, -1))
            {
                Bottom_Left_Connection.SetActive(true);
                continue;
            }
            //Left
            if (dot == GetDotByOffset(-1, 0))
            {
                Left_Connection.SetActive(true);
                continue;
            }
            //TOP-Left
            if (dot == GetDotByOffset(-1, 1))
            {
                Top_Left_Connection.SetActive(true);
                continue;
            }
        }
    }

    public void ClickDot()
    {
        if(wasClicked == false)
        {
            myPlayer = TourManager.playersQueue.Peek();
            sprite.color = myPlayer.myColor;
            SetConnectionsColor();
            wasClicked = true;
            ConnectIfPossible(null,null,this);
            tourManag.SetNextTour();
        }
    }

    void SetConnectionsColor()
    {

        Top_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Top_Right_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Right_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Bottom_Right_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Bottom_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Bottom_Left_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Left_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
        Top_Left_Connection.GetComponent<SpriteRenderer>().color = myPlayer.myColor;
    }
}
