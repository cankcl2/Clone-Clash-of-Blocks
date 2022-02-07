using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint1 : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] bool isPlaceable;
    public static Vector3 posCoords;

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            posCoords = transform.position;
            int iUpdated = ((int)(posCoords.x / 10f));
            int jUpdated = ((int)(posCoords.z / 10f));
            //Debug.Log(iUpdated + "-" + jUpdated);
            FindObjectOfType<GridManager1>().iUpdated = iUpdated;
            //Debug.Log(FindObjectOfType<GridManager>().iUpdated + "-" + FindObjectOfType<GridManager>().iUpdated);
            FindObjectOfType<GridManager1>().jUpdated = jUpdated;
            //Debug.Log(FindObjectOfType<GridManager>().iUpdated + "-" + FindObjectOfType<GridManager>().iUpdated);
            FindObjectOfType<GridManager1>().gameStarted = true;
        }
    }

    void OnTouchDown()
    {
        var touchCount = Input.touchCount;
        if (touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if (isPlaceable)
            {
                posCoords = transform.position;
                int iUpdated = ((int)(posCoords.x / 10f));
                int jUpdated = ((int)(posCoords.z / 10f));
                FindObjectOfType<GridManager1>().gameStarted = true;
            }
        }
    }
}
