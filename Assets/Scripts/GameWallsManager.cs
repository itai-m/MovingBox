using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWallsManager : MonoBehaviour {
    public float delta = 0.2f;
    private BoxCollider2D bottomWall;
    private BoxCollider2D topWall;
    private BoxCollider2D leftWall;
    private BoxCollider2D rightsWall;

    public const string allWalls = "AllWalls";
    public const string bottomWallName = "BottomWall";
    public const string topWallName = "TopWall";
    public const string leftWallName = "LeftWall";
    public const string rightsWallName = "RightsWall";

    private Transform wallHolder;

    public GameObject wallPrefabs;

    // Use this for initialization
    void Start () {
    }
    
    private void CreateAllWalls() {
        wallHolder = new GameObject(allWalls).transform;
        topWall = CreateWall(topWallName).GetComponent<BoxCollider2D>();
        bottomWall = CreateWall(bottomWallName).GetComponent<BoxCollider2D>();
        leftWall = CreateWall(leftWallName).GetComponent<BoxCollider2D>();
        rightsWall = CreateWall(rightsWallName).GetComponent<BoxCollider2D>();
    }
	
	public void SetWallToMapSize(Vector2 mapSize) {
        if (wallHolder == null) {
            CreateAllWalls();
        }
        bottomWall.size = new Vector2(mapSize.x, 1f);
        bottomWall.offset = new Vector2(mapSize.x / 2f - 0.5f, -1f - delta);

        topWall.size = new Vector2(mapSize.x, 1f);
        topWall.offset = new Vector2(mapSize.x / 2f - 0.5f, mapSize.y + delta * 2f);

        leftWall.size = new Vector2(1f, mapSize.y);
        leftWall.offset = new Vector2(-1f - delta, mapSize.y / 2f - 0.5f);

        rightsWall.size = new Vector2(1f, mapSize.y);
        rightsWall.offset = new Vector2(mapSize.x + delta, mapSize.y / 2f - 0.5f);
    }



    private GameObject CreateWall(string wallName) {
        GameObject newWall = GameObjectUtil.Instantiate(wallPrefabs, Vector3.zero, wallHolder);
        newWall.name = wallName;
        return newWall;
    }
}
