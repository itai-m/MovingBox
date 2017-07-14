using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapListElement : MonoBehaviour {

    private const int numberInList = 6;

    public void onClick() {
        transform.parent.GetComponent<MapList>().mapSelected(GetComponent<Text>().text);
        GetComponent<Text>().color = Color.cyan;
    }

    void Start() {
        Init();
    }

    public void Init() {
        //float hight = transform.parent.GetComponent<RectTransform>().rect.height;
        //GetComponent<RectTransform>().sizeDelta = new Vector2(transform.parent.GetComponent<RectTransform>().rect.width, hight / numberInList);
    }
}
    