using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public class MapSaver {

    private SavedMap map;
    private string filePath = "";

    private const string mapsFolderName = "/Maps";
    private const string coustomFolderName = "/CoustomMaps/";
    private const string mainMapsFolderName = "/MainMaps/";

    public MapSaver(int col, int row) {
        map = new SavedMap(col, row);
        CheckAndCreateFolders();
    }

    public MapSaver(SavedMap map) {
        this.map = map;
        CheckAndCreateFolders();
    }

    public MapSaver(string fileName, bool coustomMap = false) {
        CheckAndCreateFolders();
        LoadMap(fileName, coustomMap);
    }

    public MapSaver() {
        CheckAndCreateFolders();
    }

    public SavedMap GetMap() {
        return map;
    }
    
    private void CheckAndCreateFolders() {
        if (!Directory.Exists(GetMapDirPath())) {
            Directory.CreateDirectory(GetMapDirPath());
        }
        if (!Directory.Exists(GetFilePath(true))) {
            Directory.CreateDirectory(GetFilePath(true));
        }
        if (!Directory.Exists(GetFilePath(false))) {
            Directory.CreateDirectory(GetFilePath(false));
        }
    }

    /// <summary>
    /// Save a map to a file
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="coustomMap"></param>
    public void Save(string fileName, bool coustomMap = false) {
        string tempFileName = fileName;
        int index = 0;
        while(IsFileExist(tempFileName, coustomMap)) {
            tempFileName = fileName + index++;
        }
        SaveMap(tempFileName, coustomMap);
    }

    private bool IsFileExist(string fileName, bool coustomMap) {
        return File.Exists(GetFilePath(coustomMap) + fileName);
    }
    
    private void SaveMap(string fileName, bool coustomMap = false) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(GetFilePath(coustomMap) + fileName);

        bf.Serialize(file, map);
        file.Close();
    }

    public void Rename(string oldFileName, string newFileName, bool coustomMap = false) {
        File.Move(GetFilePath(coustomMap) + oldFileName, GetFilePath(coustomMap) + newFileName);
    }

    public void Delete(string fileName, bool coustomMap = false) {
        File.Delete(GetFilePath(coustomMap) + fileName);
    }

    /// <summary>
    /// Load a map from file
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="coustomMap"></param>
    /// <returns> false if the file dont exist otherwise true</returns>
    public bool LoadMap(string fileName, bool coustomMap = false) {
        if (!IsFileExist(fileName, coustomMap)) {
            return false;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenRead(GetFilePath(coustomMap) + fileName);
        map = (SavedMap)bf.Deserialize(file);
        file.Close();
        return true;
    }

    /// <summary>
    /// Get a list of file in directiory
    /// </summary>
    /// <param name="coustomMap"></param>
    /// <returns></returns>
    public string[] ListOfMaps(bool coustomMap = false, bool fullPath = true) {
        string[] result = Directory.GetFiles(GetFilePath(coustomMap));
        if (!fullPath) {
            for (int i = 0; i < result.Length; i++) {
                result[i] = result[i].Substring(GetFilePath(coustomMap).Length);
            }
        }
        return result;
    }

    public string GetFilePath(bool coustomMap) {
        return filePath + (coustomMap ? coustomFolderName : mainMapsFolderName);
    }

    private string GetMapDirPath() {
        if (filePath.CompareTo("") == 0) {
            filePath = Application.persistentDataPath + mapsFolderName;
        }
        return filePath;
    }

}

[Serializable]
public class SavedMap {
    Tile.TileType[,] map;

    public SavedMap(int col, int row) {
        map = new Tile.TileType[col, row];
    }

    public void SetTile(int col, int row, Tile.TileType tile) {
        map[col, row] = tile;
    }

    public Tile.TileType GetTile(int col, int row) {
        return map[col, row];
    }

    public Tile.TileType[,] GetMap() {
        return map;
    }

    public int GetCol() {
        return map.GetLength(0);
    }

    public int GetRow() {
        return map.GetLength(1);
    }
}