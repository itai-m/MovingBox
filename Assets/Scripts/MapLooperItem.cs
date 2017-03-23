using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
    public class MapLooperItem : MonoBehaviour {

        private Vector2 mapsize;

        public float deltaX = 0.5F;
        public float deltaY = 0.5F;

        public float deltaPosX = 0.5F;
        public float deltaPosY = 0.5F;

        // Use this for initialization
        void Start() {
            updateMapSize();
        }

        // Update is called once per frame
        void Update() {
            if (transform.position.x <  deltaPosX) {
                transform.position = new Vector2(mapsize.x - deltaX, transform.position.y);
            } else if (transform.position.x > mapsize.x - deltaPosX) {
                transform.position = new Vector2(deltaX, transform.position.y);
            }
             if (transform.position.y < deltaPosY ) {
                transform.position = new Vector2(transform.position.x, mapsize.y - deltaY);
            } else if (transform.position.y > mapsize.y) {
                transform.position = new Vector2(transform.position.x, deltaY);
            }
        }

        public void updateMapSize() {
            mapsize = GameObject.Find("GameManager").GetComponent<BoardManager>().boardRealSize;
        } 
    }
}
