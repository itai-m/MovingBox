using Completed;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour , LevelData   {
    /// <summary>
    /// Get all the world and theirs levels
    /// </summary>
    /// <returns></returns>
    public List<LevelWorld> GetWorldLevel() {
        List<LevelWorld> worlds = new List<LevelWorld>();
        worlds.Add(new LevelWorld("test1", 3));

        return worlds;
    }

    /// <summary>
    /// Decide what happen when user press on level
    /// </summary>
    /// <param name="world"></param>
    /// <param name="level"></param>
    public void Startlevel(LevelWorld world, int level) {
        RefManager.Instance.level = level;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Call whan the user press on "pause game"
    /// </summary>
    /// <returns></returns>
    public bool PauseGame() {
        RefManager.Instance.getGameManager().PauseGame();
        return true;
    }

    /// <summary>
    /// Call when the user press "Resuem game"
    /// </summary>
    /// <returns></returns>
    public bool ResuemGame() {
        RefManager.Instance.isGamePause = true;
        SceneManager.LoadScene("Game");
        return true;
    }

    /// <summary>
    /// Choose if the level is open or not
    /// </summary>
    /// <param name="world"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public bool isLevelOpen(LevelWorld world, int level) {
        return true;
    }
}
