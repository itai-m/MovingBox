using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapList : MonoBehaviour {

    public GameObject mapNameObj;
    public GameObject renamePanel;

    private MapSaver mapSaver;

	// Use this for initialization
	void Start () {
        mapSaver = new MapSaver();
        RefManager.Instance.mapEditorName = "";
        InitMapList();
        renamePanel.GetComponent<RenamePanel>().afterSave = ResetMapList;
    }

    private void InitMapList() {
        foreach (string mapName in mapSaver.ListOfMaps(true)) {
            GameObject nameObj = GameObjectUtil.Instantiate(mapNameObj, Vector3.zero, transform);
            nameObj.transform.localScale = Vector3.one;
            nameObj.GetComponent<Text>().text = mapName.Substring(mapSaver.GetFilePath(true).Length);
        }
    }

    public void mapSelected(string selected) {
        RefManager.Instance.mapEditorName = selected;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetComponent<Text>().color = Color.black;
        }
    }
	
    public void Rename() {
        if (RefManager.Instance.mapEditorName.Length != 0) {
            renamePanel.gameObject.SetActive(true);
        }
    }

    public void Delete() {
        mapSaver.Delete(RefManager.Instance.mapEditorName, true);
        ResetMapList();
    }

    private void CleanMapList() {
        for (int i = 0; i < transform.childCount; i++) {
            GameObjectUtil.Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void ResetMapList() {
        CleanMapList();
        InitMapList();
    }


}
