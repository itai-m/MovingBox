using UnityEngine;
using UnityEngine.SceneManagement;

namespace Completed {

    public class GameManager : MonoBehaviour {

        private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
        private int level = 0;


        //Awake is always called before any Start functions
        void Awake() {
            //Get a component reference to the attached BoardManager script
            boardScript = GetComponent<BoardManager>();

            //Call the InitGame function to initialize the first level 
            InitGame();
        }

        //Initializes the game for each level.
        public void InitGame() {
            level = RefManager.Instance.level;
            if (RefManager.Instance.mapEditorName.Length != 0) {
                boardScript.SetupWithMap(RefManager.Instance.mapEditorName);
            }
            else {
                //Call the SetupScene function of the BoardManager script, pass it current level number.
                boardScript.SetupScene(level);
            }
            
        }

        //Update is called every frame.
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                ResetLevel();
            }
        }

        public void nextLevel() {
            boardScript.SetupScene(++level);
        }

        public void ResetLevel() {
            boardScript.SetupScene(level);
        }

        public void OpenLevel(LevelWorld world, int newLevel) {
            boardScript.SetupScene(newLevel);
        }

        public void PauseGame() {
            
        }
    }
}