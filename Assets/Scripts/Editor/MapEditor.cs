using System.IO;
using UnityEditor;
using UnityEngine;

public class MapEditor : EditorWindow
{
    [MenuItem("Window/MapEditor")]
    public static void OpenCustomWindow()
    {
        var window = EditorWindow.GetWindow(typeof(MapEditor));
        var title = new GUIContent(EditorGUIUtility.IconContent("EditorSettings Icon"));
        title.text = "MapEditor";
        window.titleContent = title;
        window.wantsMouseMove = true;
    }

    public string FileName;

    private int _money;
    private int _startHP;
    private int _wafesCount = 0;
    private int[] _mobID = null;
    private int[] _mobCount = null;
    private int[] _mobDelay = null;
    private int[] _mobCooldown = null;

    private Vector2Int _mapSize;
    private Vector2Int _mapSizeTemp;
    private int[,] _map = new int[10,10];


    private Vector2 _scrollPos;

    private void OnGUI()
    {
        if(_mapSizeTemp!= _mapSize)
        {
            _mapSizeTemp = _mapSize;
            _map = new int[_mapSizeTemp.x, _mapSizeTemp.y];
        }
        EditorGUILayout.BeginHorizontal();
        _scrollPos =
            EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

        FileName = EditorGUILayout.TextField("Save Path", FileName);

        _money = EditorGUILayout.IntField("Start Money", _money);
        _startHP = EditorGUILayout.IntField("Start Base HP", _startHP);

        _wafesCount = EditorGUILayout.IntField("Wafes Count", _wafesCount);
        if (_wafesCount < 0) _wafesCount = 0;
        if (_mobID == null || _wafesCount != _mobID.Length)
        {
            _mobID = new int[_wafesCount];
            _mobCount = new int[_wafesCount];
            _mobDelay = new int[_wafesCount];
            _mobCooldown = new int[_wafesCount];
        }
        else
        {
            for (int i = 0; i < _wafesCount; i++)
            {
                EditorGUILayout.LabelField($"Wafe - {i}");
                _mobID[i] = EditorGUILayout.IntField("Mob ID", _mobID[i]);
                if (_mobID[i] < 0) _mobID[i] = 0;
                _mobCount[i] = EditorGUILayout.IntField("Mob Count", _mobCount[i]);
                if (_mobCount[i] < 0) _mobCount[i] = 0;
                _mobDelay[i] = EditorGUILayout.IntField("Mob Delay", _mobDelay[i]);
                if (_mobDelay[i] < 0) _mobDelay[i] = 0;
                _mobCooldown[i] = EditorGUILayout.IntField("Mob Cooldown", _mobCooldown[i]);
                if (_mobCooldown[i] < 0) _mobCooldown[i] = 0;
                EditorGUILayout.LabelField($"");
            }
        }

        _mapSize = EditorGUILayout.Vector2IntField("Map Size", _mapSize);

        EditorGUILayout.LabelField($"");

        for (int x = 0; x < _mapSizeTemp.x; x++)
        {
            GUILayout.BeginHorizontal();
            for (int y = 0; y < _mapSizeTemp.y; y++)
            {
                _map[x,y] = EditorGUILayout.IntField("", _map[x,y],GUILayout.MaxWidth(20));
            }
            GUILayout.EndHorizontal();
        }
        EditorGUILayout.LabelField($"");
        if (GUILayout.Button("Generate Json File"))
        {
            GenerationData data = new GenerationData();
            data.StartMoney = _money;
            data.StartBaseHP = _startHP;
            data.MapSize = _mapSizeTemp;

            for (int i = 0; i < _wafesCount; i++)
            {
                data.Waves.Add(new WafeData(_mobID[i], _mobCount[i], _mobDelay[i], _mobCooldown[i]));
            }

            for (int x = 0; x < _mapSizeTemp.x; x++)
            {
                for (int y = 0; y < _mapSizeTemp.y; y++)
                {
                    data.Map.Add(new Vector3Int(x, y, _map[x, y]));
                }
            }
            File.Create(Application.dataPath+FileName+".json").Close();
            File.WriteAllText(Application.dataPath + FileName + ".json", JsonUtility.ToJson(data));
        }

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();
    }
}