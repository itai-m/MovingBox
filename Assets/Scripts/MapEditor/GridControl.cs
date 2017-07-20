using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Control the grid for the map edior also save and load maps to the grid
/// </summary>
public class GridControl : MonoBehaviour {
    // Save the columns size
    public int col = 10;
    //Save the rows size
    public int row = 5;

    //Save the layout of the grid with all buttons
    private GridLayoutGroup grid;

    //Save the reltion between the button size and the space between them
    private float buttonSpaceRelHight = 1F;
    private float buttonSpaceRelWide = 1F;

    //Save the prefabs of the map editor button
    public GameObject genricMapEditorButton;

    //Save the rename panel prefabs
    public GameObject renamePanelObj;
    //Save the rename script
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

    /// <summary>
    /// initialization the col and row from the refManager
    /// </summary>
    private void InitDimansionsFromRefManager() {
        col = RefManager.Instance.mapEditorCol;
        row = RefManager.Instance.mapEditorRow;
    }
    
    /// <summary>
    /// Load a map from the RefManager
    /// </summary>
    /// <returns>return true if the function loaded map otherwise false</returns>
    private bool loadMap() {
        if (RefManager.Instance.mapEditorName.Length == 0) {
            return false;
        }
        MapSaver mapSaver = new MapSaver(RefManager.Instance.mapEditorName, true);
        ConvertMapToGrid(mapSaver.GetMap());
        return true;
    }

    /// <summary>
    /// Add empty buttons to the grid
    /// </summary>
    private void AddEmptyButtonsToGrid() {
        initGridLayout();
        for (int i = 0; i < col * row; i++) {
            GameObject newTile = GameObjectUtil.Instantiate(genricMapEditorButton, Vector2.zero, transform);
            newTile.transform.localScale = Vector3.one;
        }
    }

    /// <summary>
    /// initialization the gird layout
    /// </summary>
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

    /// <summary>
    /// Get the tile gameObject by x and y
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public GameObject getTileButton(int x, int y) {
        if (x > col || y > row) {
            return null;
        }
        return transform.GetChild(y * col + x).gameObject;
    }

    /// <summary>
    /// Open the rename panel and send him the rights functions
    /// </summary>
    public void SaveMap() {
        OpenNamePanel();
        renamePanel.afterSave = AfterSave;
        renamePanel.saveMapFun = SaveMap;
    }

    /// <summary>
    /// The function that save the map after the rename panel
    /// </summary>
    /// <param name="mapName"></param>
    public void SaveMap(string mapName) {
        MapSaver mapSaver = new MapSaver(ConvertGridToMap());
        mapSaver.Save(mapName, true);
    }

    private void AfterSave() {
        //TODO: send a msg that its save the map
    }

    /// <summary>
    /// Opend the Name panel (rename)
    /// </summary>
    private void OpenNamePanel() {
        renamePanelObj.SetActive(true);
    }

    /// <summary>
    /// Convert Map to the grid the mapeditor
    /// </summary>
    /// <param name="map"></param>
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

    /// <summary>
    /// Convert the grid on the screen to a map object
    /// </summary>
    /// <returns></returns>
    private SavedMap ConvertGridToMap() {
        SavedMap map = new SavedMap(col, row);
        for (int j = 0; j < row; j++) {
            for (int i = 0; i < col; i++) {
                map.SetTile(i, j, GetTileType(i, j));
            }
        }
        return map;
    }

    /// <summary>
    /// Get the tile type from the grid from the x and y
    /// </summary>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    private Tile.TileType GetTileType(int col, int row) {
        return getTileButton(col, row).GetComponent<TileMapEditorButton>().getTileType();
    }
}
