using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject TilePrefab;
    public GameObject EmptyTilePrefab;
    public int gridSize;
    public int tileSize;
    GameObject[,] TilesArray;
    Dot[,] DotsArray;

    void Start()
    {
        DotsManager.gridSize = gridSize;
        DotsManager.DotsArray = new Dot[gridSize, gridSize];
        InstantiateArray();
    }

    void Update()
    {
        
    }

    void InstantiateArray()
    {
        TilesArray = new GameObject[gridSize,gridSize];
        GameObject TilesFolder = new GameObject();
        TilesFolder.name = "Tiles";
        float gridPosAdjust = (gridSize * tileSize) / 2;

        for (int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                Vector2 pos;
                pos.x = (i * tileSize) - gridPosAdjust;
                pos.y = (j * tileSize) - gridPosAdjust;
                Quaternion rot = new Quaternion();

                if (j > 0 && i > 0) TilesArray[i, j] = Instantiate(TilePrefab, pos, rot);
                else TilesArray[i, j] = Instantiate(EmptyTilePrefab, pos, rot);
                TilesArray[i, j].transform.parent = TilesFolder.transform;
                if(TilesArray[i, j].GetComponent<Tile>() != false)
                {
                    TilesArray[i, j].GetComponent<Tile>().index = new Vector2(i, j);
                    Dot dot = TilesArray[i, j].GetComponent<Tile>().myDot;
                    dot.index = new Vector2(i, j);
                    DotsManager.DotsArray[i, j] = dot;
                }
            }
        }
    }
}
