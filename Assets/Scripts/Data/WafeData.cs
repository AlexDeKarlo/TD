using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WafeData
{
    public WafeData()
    {

    }
    public WafeData(int MobID,int Count, float delay, float spawnCooldown)
    {
        this.MobID = MobID;
        this.Count = Count;
        Delay = delay;
        SpawnCooldown = spawnCooldown;
    }
    public int MobID;
    public int Count;
    public float Delay;
    public float SpawnCooldown;
}
