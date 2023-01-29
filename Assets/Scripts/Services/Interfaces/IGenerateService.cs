using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenerateService
{
    public List<Block> Generate(GenerationData data);
}
