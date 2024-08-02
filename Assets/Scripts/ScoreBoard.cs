using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public List<GameObject> planes;
    public float planeHeight;
    public float ShowSpeed;
    Vector3 StartPos;

    private void Start()
    {
        StartPos = GetComponent<RectTransform>().position;
        int index = 0;
        foreach(var plr in TourManager.playersQueue)
        {
            AssinPlaneToPlayer(index, plr);
            index++;
        }
    }

    void AssinPlaneToPlayer(int planeIndex, Player plr)
    {
        GameObject obj = planes[planeIndex];
        obj.GetComponent<Image>().color = plr.myColor;
        obj.GetComponentInChildren<NameTag>().gameObject.GetComponent<TextMeshProUGUI>().text = plr.Name;
        obj.GetComponentInChildren<ScoreTag>().gameObject.GetComponent<TextMeshProUGUI>().text = "0";
    }

    public void Show()
    {
        float posY = StartPos.y + planeHeight * TourManager.playersQueue.Count - 1;
        GetComponent<RectTransform>().position = new Vector3(StartPos.x, Mathf.Lerp(GetComponent<RectTransform>().position.y, posY, ShowSpeed * Time.deltaTime) , 0);
    }
    public void Hide()
    {
        GetComponent<RectTransform>().position = new Vector3(StartPos.x, Mathf.Lerp(GetComponent<RectTransform>().position.y, StartPos.y, ShowSpeed * Time.deltaTime), 0);
    }

    public void RearrangeQueue()
    {
        int index = 0;
        foreach (var plr in TourManager.playersQueue)
        {
            AssinPlaneToPlayer(index, plr);
            index++;
        }
    }

}
