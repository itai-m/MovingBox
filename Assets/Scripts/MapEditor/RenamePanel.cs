using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenamePanel : MonoBehaviour {

    private MapSaver mapSaver;
    public Text textMapName;

    public delegate void AfterSave();
    public AfterSave afterSave;

	// Use this for initialization
	void Start () {
        mapSaver = new MapSaver();
	}

	
	private bool IsMapExist(string mapName) {
        string[] mapList = mapSaver.ListOfMaps(true);
        for (int i = 0; i < mapList.Length; i++) {
            if (mapList[i].Equals(mapName)) {
                return true;
            }
        }
        return false;
    }

    private bool validName(string name) {
        return (name == null || name.Length == 0);
    }

    public void SaveMap() {
        string newName = textMapName.text;
        if (validName(newName)) {
            return;
        }
        mapSaver.Rename(RefManager.Instance.mapEditorName, newName, true);
        afterSave();
        ClosePanel();
    }

    public void ClosePanel() {
        gameObject.SetActive(false);
    }
}
