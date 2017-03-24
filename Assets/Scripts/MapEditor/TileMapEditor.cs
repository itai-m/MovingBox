#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {

    public TileMap map;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        EditorGUILayout.BeginVertical();
        map.mapSize = EditorGUILayout.Vector2Field("Map Size:", map.mapSize);
        map.texture2D = (Texture2D)EditorGUILayout.ObjectField("Texture2D:", map.texture2D, typeof(Texture2D), false);

        if (map.texture2D == null) {
            EditorGUILayout.HelpBox("You must selected texture 2D", MessageType.Warning);
        } else {
            EditorGUILayout.LabelField("Tile Size:", map.tileSize.x + "X" + map.tileSize.y);
        }

        EditorGUILayout.EndVertical(); ;
    }

    private void OnEnable() {
        map = target as TileMap;
        Tools.current = Tool.View;

        if (map.texture2D != null) {
            var path = AssetDatabase.GetAssetPath(map.texture2D);
            map.spriteRefernces = AssetDatabase.LoadAllAssetsAtPath(path);
            var sprite = (Sprite)map.spriteRefernces[1];
            var width = sprite.textureRect.width;
            var height = sprite.textureRect.height;

            map.tileSize = new Vector2(width, height);
        }
    }

}
#endif
