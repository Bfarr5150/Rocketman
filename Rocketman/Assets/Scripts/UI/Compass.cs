using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RectTransform compassNeedle;
    public RectTransform compassSpan;
    public RectTransform levelBounds;

    public Transform playerLoc;
    public Transform platformLoc;
    public Transform boundaryL;
    public Transform boundaryR;

    float platformWidth;

    void Start()
    {
        float stageWidth = boundaryR.localPosition.x - boundaryL.localPosition.x;
        platformWidth = platformLoc.localScale.x;

        float platformWidthPercentage = platformWidth / stageWidth;

        levelBounds.sizeDelta = new Vector2(512, levelBounds.sizeDelta.y);
        compassSpan.sizeDelta = new Vector2(platformWidthPercentage * 512, compassSpan.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = platformLoc.localPosition.x - playerLoc.localPosition.x;
        distance += (platformWidth / 2);
        float distancePercentage = (distance / platformWidth) - (.5f);

        Debug.Log(distancePercentage);

        compassNeedle.anchoredPosition = new Vector2(distancePercentage * -compassSpan.sizeDelta.x, 150f);
    }
}
