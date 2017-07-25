using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
    public class MapLooperItem : MonoBehaviour {

        private const string tagName = "OtterWalls";
        private Vector2 mapsize;
        private BoardManager boardManager;

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
            
        }

        void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag.Equals(tagName)) {
                TryMovePlayerToOtherSide(collision.gameObject.name);
            }
        }

        private void OnCollisionStay2D(Collision2D collision) {
            if (collision.gameObject.tag.Equals(tagName)) {
                TryMovePlayerToOtherSide(collision.gameObject.name);
            }
        }

        private void TryMovePlayerToOtherSide(string colliderName) {
            if (colliderName.Equals(GameWallsManager.leftWallName)) {
                TryMoveToPosition(new Vector2(mapsize.x - deltaX, transform.position.y));
            }
            else if (colliderName.Equals(GameWallsManager.rightsWallName)) {
                TryMoveToPosition(new Vector2(-deltaX, transform.position.y));
            }
            else if (colliderName.Equals(GameWallsManager.bottomWallName)) {
                TryMoveToPosition(new Vector2(transform.position.x, mapsize.y - deltaY));
            }
            else if (colliderName.Equals(GameWallsManager.topWallName)) {
                TryMoveToPosition(new Vector2(transform.position.x + 0.5f, -deltaY));
            }
        }

        private void TryMoveToPosition(Vector2 newPos) {
            if (boardManager.CanMoveToPosition(newPos)) {
                transform.position = newPos;
            }
        }

        public void updateMapSize() {
            boardManager = RefManager.Instance.GetBoardManager();
            mapsize = boardManager.boardRealSize;
        } 
    }
}
