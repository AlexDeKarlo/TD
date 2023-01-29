using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GenerateService : MonoBehaviour, IGenerateService
{
    [SerializeField] protected List<Block> _generationDictionaries = new List<Block>();
    [Inject] DiContainer _container;
    public List<Block> Generate(GenerationData data)
    {
        List<Block> blocks = new List<Block>();
        List<Vector3Int> Map = data.Map;
        int tempID = 0;
        GameObject parent = new GameObject();
        parent.name = "Map";

        for (int X = 0; X < data.MapSize.x; X++)
        {
            for (int Y = 0; Y < data.MapSize.y; Y++)
            {
                
               blocks.Add(Spawn(new Vector3(X, 0, Y), Map[tempID].z,parent.transform));
                tempID++;
            }
        }
        return blocks;
    }
    private Block Spawn(Vector3 pos, int id,Transform parent)
    {
        for (int i = 0; i < _generationDictionaries.Count; i++)
        {
            if (i == id)
            {
                Block block = _container.InstantiatePrefab(_generationDictionaries[i], pos, Quaternion.identity, parent).GetComponent<Block>();
                return block;
            }
                
        }
        return null;
    }
}
