using UnityEngine;
<<<<<<< HEAD

=======
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab

namespace Completed {

    public class BoardManager : MonoBehaviour {


        public int columns = 8;                                         //Number of columns in our game board.
        public int rows = 8;                                            //Number of rows in our game board.
        public GameObject exit;                                         //Prefab to spawn for exit.
        public GameObject mapHolder;
        private Map map;
<<<<<<< HEAD
=======
        private int currentLevel;
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
        public GameObject cameraToAjust;
        public GameObject player;

        public Vector2 boardRealSize;

<<<<<<< HEAD
        public Map Map {
            get { return map; }
        }

=======
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
        //SetupScene initializes our level and calls the previous functions to lay out the game board
        public void SetupScene(int level) {
            initMap();
            CleanMap();
            loadMap(level);
            AjustCam();
        }

<<<<<<< HEAD
        public void SetupWithMap(Map newMap, int level) {
            initMap();
            map = newMap;
            columns = map.col;
            rows = map.row;
            AjustCam();
        }

=======
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
        private void AjustCam() {
            cameraToAjust.GetComponent<AjustCam>().ajustCam(columns, rows);
        }

        private void loadMap(int level) { 
            if (level == 0) {
                map.loadExmpleMap();
            } else {
                map.loadMap1();
            }
            
            instantiateMap(mapHolder);
            setBoardRealSize();
            setPlayerPostion();
        }

        private void instantiateMap(GameObject perent) {
            columns = map.col;
            rows = map.row;
            for (int i = 0; i < columns; i++) {
                for (int j = 0; j < rows; j++) {
                    if (map.tileIn(i,j) != null) {
                        GameObject temp = GameObjectUtil.Instantiate(map.tileIn(i, j), new Vector2(i, j), perent.transform);
                        MoveingBox moveingBox = temp.GetComponent<MoveingBox>();
                        if (moveingBox != null) {
                            moveingBox.pos = new Postion2D(i, j);
                        }
                    }
                }
            }
        }

        private void CleanMap() {
            for (int i = 0; i < mapHolder.transform.childCount; i++) {
                GameObjectUtil.Destroy(mapHolder.transform.GetChild(i).gameObject);
            }
        }

        private void initMap() {
            if (mapHolder == null) {
                map = GetComponent<Map>();
                mapHolder = new GameObject("Map");
            }
        }

        public bool CanMoveTile(Postion2D to) {
            return map.isEmptyTile(to);
        }

        public void swapTiles(Postion2D from, Postion2D to) {
            map.swapTiles(from, to);
        }

        private void setBoardRealSize() {
            boardRealSize = new Vector2(columns, rows);
            player.GetComponent<MapLooperItem>().updateMapSize();
        }

        private void setPlayerPostion() {
            player.gameObject.transform.position = map.playerStart;
        }
    } 
}