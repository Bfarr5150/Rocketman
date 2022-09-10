using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RectTransform compassNeedle;
    public RectTransform compassSpan;

    public Transform playerLoc;
    public Transform platformLoc;
    public Transform boundaryL;
    public Transform boundaryR;

    float platformWidth;

    // Update is called once per frame
    void Update()
    {
        platformWidth = platformLoc.localScale.x;
        float distance = platformLoc.localPosition.x - playerLoc.localPosition.x;
        distance += (platformWidth / 2);
        float distancePercentage = (distance / platformWidth) - (.5f);

        Debug.Log(distancePercentage);

        compassNeedle.anchoredPosition = new Vector2(distancePercentage * -400, 150f);
    }
}
