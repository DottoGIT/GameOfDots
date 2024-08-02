using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraSpeed;
    public float cameraScrollSpeed;

    public float maxCameraSize;
    public float minCameraSize;

    public ScoreBoard scoreBoardUI;

    float maxBoundries;
    Camera cam;
    TileSpawn tileManag;

    private void Start()
    {
        cam = GetComponent<Camera>();
        tileManag = FindObjectOfType<TileSpawn>();

        maxBoundries = (tileManag.gridSize * tileManag.tileSize) / 2;
    }

    void Update()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        foreach (var obj in raycastResultList)
        {
            if(obj.gameObject.GetComponent<CameraMovementTrigger>() != null)
            {
                gameObject.transform.position += obj.gameObject.GetComponent<CameraMovementTrigger>().vector * cameraSpeed * Time.deltaTime;
            }
            if(obj.gameObject.GetComponent<ScoreBoard>() != null)
            {
                scoreBoardUI.Show();
            }
        }
        if(raycastResultList.Count == 0)
        {
            scoreBoardUI.Hide();
        }

        if (transform.position.x > maxBoundries) transform.position = new Vector3(maxBoundries, transform.position.y, -10);
        if (transform.position.x < -maxBoundries) transform.position = new Vector3(-maxBoundries, transform.position.y, -10);
        if (transform.position.y > maxBoundries) transform.position = new Vector3(transform.position.x, maxBoundries, -10);
        if (transform.position.y < -maxBoundries) transform.position = new Vector3(transform.position.x, -maxBoundries, -10);

        if (Input.mouseScrollDelta.y > 0 && cam.orthographicSize > minCameraSize) cam.orthographicSize -= cameraScrollSpeed * Time.deltaTime;
        if (Input.mouseScrollDelta.y < 0 && cam.orthographicSize < maxCameraSize) cam.orthographicSize += cameraScrollSpeed * Time.deltaTime;
    }
}
