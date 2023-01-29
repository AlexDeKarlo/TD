using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenerationData
{
    public int StartMoney;
    public int StartBaseHP;
    public Vector2Int MapSize;
    public List<WafeData> Waves = new List<WafeData>();
    public List<Vector3Int> Map = new List<Vector3Int>();
}
