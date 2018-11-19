using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class autoDivWidth : MonoBehaviour {

    public RectTransform parentRect;
    public GridLayoutGroup gridLayout;

	// Use this for initialization
	void Start () {

        float size = (parentRect.rect.width / gridLayout.constraintCount) - (gridLayout.spacing.x) + gridLayout.spacing.x/ gridLayout.constraintCount;

        gridLayout.cellSize = new Vector2(size, gridLayout.cellSize.y);

    }
}
