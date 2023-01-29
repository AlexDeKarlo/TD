using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILinkService
{
    public void Link(List<Block> blocks);
    public StartBlock StartBlock { get; }
    public EndBlock EndBlock { get; }
}
