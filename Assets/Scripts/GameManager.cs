using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;

namespace Completed {
    using System;
=======
using System.Collections;
using UnityEngine.SceneManagement;

namespace Completed {
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
    using System.Collections.Generic;       //Allows us to use Lists. 

    public class GameManager : MonoBehaviour {

<<<<<<< HEAD
        private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
        private int level = 0;


        //Awake is always called before any Start functions
        void Awake() {
            //DontDestroyOnLoad(transform.gameObject);
=======
        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
        private int level = 0;                                  //Current level number, expressed in game as "Day 1".

        //Awake is always called before any Start functions
        void Awake() {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
            //Get a component reference to the attached BoardManager script
            boardScript = GetComponent<BoardManager>();

            //Call the InitGame function to initialize the first level 
            InitGame();
        }

        //Initializes the game for each level.
<<<<<<< HEAD
        public void InitGame() {
            level = RefManager.Instance.level;
            if (RefManager.Instance.isGamePause) {
                boardScript.SetupWithMap(RefManager.Instance.savedMap, level);
            }
            else {
                //Call the SetupScene function of the BoardManager script, pass it current level number.
                boardScript.SetupScene(level);
            }
            
        }

=======
        void InitGame() {
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            //boardScript.SetupScene(level);

        }



>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
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

        public void OpenMapEditor() {
            SceneManager.LoadScene("MapEditor");
        }
<<<<<<< HEAD

        public void OpenLevel(LevelWorld world, int newLevel) {
            boardScript.SetupScene(newLevel);
        }

        public void PauseGame() {
            RefManager.Instance.savedMap = boardScript.Map;
        }
=======
>>>>>>> fef21a562409a4a88c84ea3c8e4d97d9a6bd29ab
    }
}