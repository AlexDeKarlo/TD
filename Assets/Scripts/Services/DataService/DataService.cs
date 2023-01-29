using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataService : MonoBehaviour, IDataService
{
    public abstract GenerationData GetData();
}
