using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorManager : MonoBehaviour {

    public GameObject TilePickPanel;
    public GameObject GridPanel;
    public GameObject menuPanel;

    private TilePicker picker;
    private GridControl grid;

    // Use this for initialization
    void Start () {
        picker = TilePickPanel.GetComponent<TilePicker>();
        grid = GridPanel.GetComponent<GridControl>();
	}

    public void InitMapEditor(int col, int row) {

    }

    public void loadMap() {

    }

    public void SaveMap() {
        grid.SaveMap();
    }

    public Tile.TileType getSelectedTile() {
        return picker.getSelectedTile();
    }

    public void openMenu() {
        menuPanel.SetActive(true);
    }

    public void closeMenu() {
        menuPanel.SetActive(false);
    }
}
