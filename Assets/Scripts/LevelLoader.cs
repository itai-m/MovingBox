using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// This static class load Levels for the asset bundel,
/// 
/// note: all files in the asset bundel in to be in this format [worldName]_[levelNumber].txt
/// the levels in ehce world needs to start with 0 and then go in ascending order
/// </summary>
public static class LevelLoader {

    private const char sepertor = '_';
    private static List<LevelWorld> allWorld;
    private const string levelFolder = "LevelsBundle";
    private const char slashChar = '/';
    private const string fileSufix = ".txt";

    private static AssetBundle bundle;

    public static List<LevelWorld> GetWorlds() {
        if (allWorld == null) {
            allWorld = CreatWorldList();
        }
        return allWorld;
    }
    
    private static AssetBundle getAssetBundle() {
        if (bundle == null) {
            bundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, levelFolder));
        }
        return bundle;
    }

    private static List<LevelWorld> CreatWorldList() {
        return CreatWorldListFromNames(getAssetBundle().GetAllAssetNames());
    }

    private static List<LevelWorld> CreatWorldListFromNames(string[] fileNames) {
        List<LevelWorld> result = new List<LevelWorld>();
        Dictionary<string,int> worldDictionary = new Dictionary<string, int>();
        foreach (string fileName in fileNames) {
            string worldName = GetWorldName(fileName);
            if (worldDictionary.ContainsKey(worldName)) {
                worldDictionary[worldName] = worldDictionary[worldName] + 1;
            }
            else {
                worldDictionary.Add(worldName, 1);
            }
        }
        foreach (KeyValuePair<string, int> entry in worldDictionary) {
            result.Add(new LevelWorld(entry.Key, entry.Value));
        }
        return result;
    }

    private static string GetWorldName(string fileName) {
        string[] splitName = fileName.Split(slashChar);
        return splitName[splitName.Length -1].Split(sepertor)[0];
    }

    private static int GetLevelNumber(string fileName) {
        int result = 0;
        string nameSufix = fileName.Split(sepertor)[1];
        if (!int.TryParse(nameSufix.Substring(0, nameSufix.Length - fileSufix.Length) , out result)) {
            return -1;
        }
        return result;
    }

    public static SavedMap GetMap(string worldName, int level) {
        TextAsset binFile = getAssetBundle().LoadAsset(worldName + sepertor + level + fileSufix) as TextAsset;
        MapSaver saver = new MapSaver(binFile);
        return saver.GetMap();
    }
}
