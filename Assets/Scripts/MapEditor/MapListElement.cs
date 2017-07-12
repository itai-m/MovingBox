using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapListElement : MonoBehaviour {

    public void onClick() {
        transform.parent.GetComponent<MapList>().mapSelected(GetComponent<Text>().text);
        GetComponent<Text>().color = Color.cyan;
    }

}
    