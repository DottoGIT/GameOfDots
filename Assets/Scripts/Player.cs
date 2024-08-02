using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public string Name;
    public int Score;
    public Color myColor;
}
