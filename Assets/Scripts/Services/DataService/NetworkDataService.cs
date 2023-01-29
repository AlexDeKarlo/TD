using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDataService : DataService
{
    public override GenerationData GetData()
    {
        Debug.Log("Network");
        return null;
    }
}
