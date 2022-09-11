using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RectTransform compassNeedle;
    public RectTransform platformIndicator;
    public RectTransform levelBoundIndicators;

    public Transform playerLoc;
    public Transform platformLoc;
    public Transform boundaryL;
    public Transform boundaryR;

    float platformWidth;
    float stageWidth;

    void Start()
    {
        stageWidth = boundaryR.localPosition.x - boundaryL.localPosition.x;
        platformWidth = platformLoc.localScale.x;

        float platformWidthPercentage = platformWidth / stageWidth;

        // Set platform span indicator to cover an equal percentage of the space between boundary indicators as the actual platform spans inbetween the level bounds.
        platformIndicator.sizeDelta = new Vector2(platformWidthPercentage * levelBoundIndicators.sizeDelta.x, levelBoundIndicators.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Update compass needle realtive to percentage of the total distance of playfield player is from the left boundary
        compassNeedle.anchoredPosition = new Vector2((((playerLoc.localPosition.x - boundaryL.localPosition.x) / stageWidth) * levelBoundIndicators.sizeDelta.x) - (levelBoundIndicators.sizeDelta.x / 2), levelBoundIndicators.anchoredPosition.y);

        // Update platform indicator realtive to percentage of the total distance of playfield platform is from the left boundary
        platformIndicator.anchoredPosition = new Vector2((((platformLoc.localPosition.x - boundaryL.localPosition.x) / stageWidth) * levelBoundIndicators.sizeDelta.x) - (levelBoundIndicators.sizeDelta.x / 2), levelBoundIndicators.anchoredPosition.y);
    }
}
