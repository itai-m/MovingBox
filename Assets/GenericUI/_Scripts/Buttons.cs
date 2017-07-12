using UnityEngine;

public class Buttons : MonoBehaviour {

    public void LoadLevelSelector() {
        UIManager.Instance.LoadLevelSelector();
    }

    public void LoadSettingScreen() {
        UIManager.Instance.LoadSettingScreen();
    }

    public void LoadMainScreen() {
        UIManager.Instance.LoadMainMenu();
    }

    public void PauseGame() {
        UIManager.Instance.PauseGame();
    }

    public void ResumeGame() {
        UIManager.Instance.ResuemGame();
    }

    public void CurrentLevelCompleted() {
        UIManager.Instance.CurrentLevelCompleted();
    }

    public void LevelSelect() {
        
    }

    public void nextWorld() {
        LevelSelector.Instance.nextWorld();
    }

    public void prevWorld() {
        LevelSelector.Instance.previsWorld();
    }

    public void LoadEditorUI() {
        UIManager.Instance.LoadMapEditorUI();
    }

    public void LoadMapList(bool forPlay) {
        UIManager.Instance.LoadMapList(forPlay);
    }

    public void MapListLoad() {
        UIManager.Instance.MapListLoad();
    }

    public void LoadMapEditor() {
        UIManager.Instance.LoadMapEditor();
    }
}
