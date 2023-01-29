using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class JsonDataService : DataService
{
    private GenerationData _data;
    public override GenerationData GetData()
    {
        if (_data != null) return _data;
        else
        {
            GenerationData data = new GenerationData();
            string path = Application.dataPath + "data.json";
            if (!File.Exists(path))
            {
                data = new GenerationData();
                data.StartMoney = 50;
                data.StartBaseHP = 100;
                data.MapSize = new Vector2Int(10, 10);

                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        data.Map.Add(new Vector3Int(x, y, 0));
                    }
                }

                WafeData wafeData1 = new WafeData();
                wafeData1.Count = 5;
                wafeData1.MobID = 0;

                WafeData wafeData2 = new WafeData();
                wafeData1.Count = 10;
                wafeData1.MobID = 0;

                WafeData wafeData3 = new WafeData();
                wafeData1.Count = 15;
                wafeData1.MobID = 0;

                data.Waves.Add(wafeData1);
                data.Waves.Add(wafeData2);
                data.Waves.Add(wafeData3);


                File.Create(path).Close();
                File.WriteAllText(path, JsonUtility.ToJson(data));
            }
            else
            {
                data = JsonUtility.FromJson<GenerationData>(File.ReadAllText(path));
            }
            _data = data;
            Debug.Log("Json Load");
            return _data;
        }
    }
}
