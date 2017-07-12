using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapList : MonoBehaviour {

    public GameObject mapNameObj;

    private MapSaver mapSaver;

	// Use this for initialization
	void Start () {
        mapSaver = new MapSaver();
        InitMapList();

    }

    private void InitMapList() {
        //for (int i = 0; i < 5; i++) {
            foreach (string mapName in mapSaver.ListOfMaps(true)) {
                GameObject nameObj = GameObjectUtil.Instantiate(mapNameObj, Vector3.zero, transform);
                nameObj.transform.localScale = Vector3.one;
                nameObj.GetComponent<Text>().text = mapName.Substring(mapSaver.GetFilePath(true).Length);
            }
        //}
    }

    public void mapSelected(string selected) {
        RefManager.Instance.mapEditorName = selected;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetComponent<Text>().color = Color.black;
        }
    }
	
}
