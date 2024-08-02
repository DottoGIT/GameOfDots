using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotUIButton : MonoBehaviour
{
    public Dot myDot;

    public void DotClicked()
    {
        myDot.ClickDot();
    }
}
