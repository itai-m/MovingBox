using Completed;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour , LevelData   {

    

    public List<LevelWorld> GetWorldLevel() {
        List<LevelWorld> worlds = new List<LevelWorld>();
        worlds.Add(new LevelWorld("test1", 3));

        return worlds;
    }

    public void Startlevel(LevelWorld world, int level) {
        RefManager.Instance.level = level;
        SceneManager.LoadScene("Game");
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public bool PauseGame() {
        RefManager.Instance.getGameManager().PauseGame();
        Screen.orientation = ScreenOrientation.Portrait;
        return true;
    }

    public bool ResuemGame() {
        RefManager.Instance.isGamePause = true;
        SceneManager.LoadScene("Game");
        return true;
    }

    public bool isLevelOpen(LevelWorld world, int level) {
        return true;
    }
}
