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

    public GameObject renamePanelObj;
    private RenamePanel renamePanel;

    // Use this for initialization
    void Start () {
        renamePanel = renamePanelObj.GetComponent<RenamePanel>();
        if (!loadMap()) {
            if (RefManager.Instance.mapEditorCol != 0 && RefManager.Instance.mapEditorRow != 0) {
                InitDimansionsFromRefManager();
            }
            AddEmptyButtonsToGrid();
        }
    }

    private void InitDimansionsFromRefManager() {
        col = RefManager.Instance.mapEditorCol;
        row = RefManager.Instance.mapEditorRow;
    }

    private void InitDefaultDimansions() {
        col = 19;
        row = 10;
    }

    private bool loadMap() {
        if (RefManager.Instance.mapEditorName.Length == 0) {
            return false;
        }
        MapSaver mapSaver = new MapSaver(RefManager.Instance.mapEditorName, true);
        ConvertMapToGrid(mapSaver.GetMap());
        return true;
    }


    private void AddEmptyButtonsToGrid() {
        initGridLayout();
        for (int i = 0; i < col * row; i++) {
            GameObject newTile = GameObjectUtil.Instantiate(genricMapEditorButton, Vector2.zero, transform);
            newTile.transform.localScale = Vector3.one;
        }
    }

    private void initGridLayout() {
        grid = GetComponent<GridLayoutGroup>();
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

    public GameObject getTileButton(int x, int y) {
        if (x > col || y > row) {
            return null;
        }
        return transform.GetChild(y * col + x).gameObject;
    }

    public void SaveMap() {
        OpenNamePanel();
        renamePanel.afterSave = AfterSave;
        renamePanel.saveMapFun = SaveMap;
    }

    public void SaveMap(string mapName) {
        MapSaver mapSaver = new MapSaver(ConvertGridToMap());
        mapSaver.Save(mapName, true);
    }

    private void AfterSave() {
        //TODO: send a msg that its save the map
    }

    private void OpenNamePanel() {
        renamePanelObj.SetActive(true);
    }

    private void ConvertMapToGrid(SavedMap map) {
        col = map.GetCol();
        row = map.GetRow();
        initGridLayout();
        
            for (int j = 0; j < row; j++) {
            for (int i = 0; i < col; i++) {
                GameObject newTile = GameObjectUtil.Instantiate(genricMapEditorButton, Vector2.zero, transform);
                newTile.transform.localScale = Vector3.one;
                newTile.GetComponent<TileMapEditorButton>().ChangeTile(map.GetTile(i, j));
            }
        }
    }

    private SavedMap ConvertGridToMap() {
        SavedMap map = new SavedMap(col, row);
        for (int j = 0; j < row; j++) {
            for (int i = 0; i < col; i++) {
                map.SetTile(i, j, GetTileType(i, j));
            }
        }
        return map;
    }

    private Tile.TileType GetTileType(int col, int row) {
        return getTileButton(col, row).GetComponent<TileMapEditorButton>().getTileType();
    }
}
