using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridControl : MonoBehaviour {
    public int col = 10;
    public int row = 5;

    private GridLayoutGroup grid;

    private float buttonSpaceRelHight = 1F;
    private float buttonSpaceRelWide = 1F;

    public GameObject genricMapEditorButton;

    // Use this for initialization
    void Start () {
        grid = GetComponent<GridLayoutGroup>();
        initGridLayout();
        AddButtonsToGrid();

    }

    private void AddButtonsToGrid() {
        for (int i = 0; i < col * row; i++) {
            GameObject newTile = GameObjectUtil.Instantiate(genricMapEditorButton, Vector2.zero, transform);
            newTile.transform.localScale = Vector3.one;
        }
    }

    private void initGridLayout() {
        RectTransform levelsPanelTransform = GetComponent<RectTransform>();
        float newPanelHight = levelsPanelTransform.rect.height;
        float buttonHight = newPanelHight * buttonSpaceRelHight / row;
        float offsetBetweenButtonHight = (newPanelHight - (buttonHight * row)) / (row - 1);
        float newPanelWidth = levelsPanelTransform.rect.width;
        float buttonWide = newPanelWidth * buttonSpaceRelWide / col;
        float offsetBetweenButtonWide = (newPanelWidth - (buttonWide * col)) / (col - 1);
        grid.spacing = new Vector2(offsetBetweenButtonWide, offsetBetweenButtonHight);
        grid.cellSize = new Vector2(buttonWide, buttonHight);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public GameObject getTileButton(int x, int y) {
        if (x > col || y > row) {
            return null;
        }
        return transform.GetChild(x * col + y).gameObject;
    }
}
