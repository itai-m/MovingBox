using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenamePanel : MonoBehaviour {

    private MapSaver mapSaver;
    public Text textMapName;

    public delegate void AfterSave();
    public AfterSave afterSave;

    public delegate void SaveMapFun(string mapName);
    public SaveMapFun saveMapFun;

    public GameObject warningManagerObj;
    private WarningManager warningManager;

	// Use this for initialization
	void Start () {
        mapSaver = new MapSaver();
        warningManager = warningManagerObj.GetComponent<WarningManager>();
	}

	
	private bool IsMapExist(string mapName) {
        string[] mapList = mapSaver.ListOfMaps(true, false);
        for (int i = 0; i < mapList.Length; i++) {
            if (mapList[i].Equals(mapName)) {
                return true;
            }
        }
        return false;
    }

    private bool validName(string name) {
        if (name == null || name.Length == 0) {
            return false;
        }
        if (IsMapExist(name)) {
            OpenWarningPanel();
            return false;
        }
        return true;
    }

    private void OpenWarningPanel() {
        warningManager.PostiveCall = SaveAndOvrride;
        warningManagerObj.SetActive(true);
    }

    public void SaveAndOvrride() {
        string newName = textMapName.text;
        mapSaver.Delete(newName, true);
        RenameAndClose(newName);
    }

    public void SaveMap() {
        string newName = textMapName.text;
        if (!validName(newName)) {
            return;
        }
        RenameAndClose(newName);
    }

    private void RenameAndClose(string newName) {
        if (saveMapFun != null) {
            saveMapFun(newName);
        }
        else {
            mapSaver.Rename(RefManager.Instance.mapEditorName, newName, true);
        }
        afterSave();
        ClosePanel();
    }

    public void ClosePanel() {
        gameObject.SetActive(false);
    }
}
