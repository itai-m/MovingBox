using UnityEngine;
using System.Collections;

public class AjustCam : MonoBehaviour {

    private float CamZ = -10;

    public void ajustCam(int col, int row) {
        float x = (float)col / 2;
        float y = (float)row / 2;
        float size = Mathf.Max(x, y);
        transform.position = new Vector3(x - 0.5F, y - 0.5F, CamZ);
        GetComponent<Camera>().orthographicSize = size;
    }
}
