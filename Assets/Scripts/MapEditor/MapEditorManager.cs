using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorManager : MonoBehaviour {

    public GameObject TilePickPanel;
    public GameObject GridPanel;

    private TilePicker picker;

    // Use this for initialization
    void Start () {
        picker = TilePickPanel.GetComponent<TilePicker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitMapEditor(int col, int row) {

    }

    public void loadMap() {

    }
}
