using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LinkService : MonoBehaviour, ILinkService
{
    [Inject] private IShopUIService _shopVisual;

    private StartBlock _startBlock;
    private EndBlock _endBlock;
    private List<PathBlock> _pathBlocks = new List<PathBlock>();

    private List<TurretBaseBlock> _turretBaseBlocks = new List<TurretBaseBlock>();

    StartBlock ILinkService.StartBlock => _startBlock;
    EndBlock ILinkService.EndBlock => _endBlock;

    public void Link(List<Block> blocks)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            TurretBaseBlock turretBaseBlock;
            PathBlock pathBlock;
            StartBlock startBlock;
            EndBlock endblock;

            turretBaseBlock = blocks[i] as TurretBaseBlock;
            pathBlock = blocks[i] as PathBlock;
            startBlock = blocks[i] as StartBlock;
            endblock = blocks[i] as EndBlock;

            if (startBlock != null) _startBlock = blocks[i] as StartBlock;
            if (endblock != null) _endBlock = blocks[i] as EndBlock;
            if (pathBlock != null) _pathBlocks.Add(blocks[i] as PathBlock);
            if (turretBaseBlock != null) _turretBaseBlocks.Add(blocks[i] as TurretBaseBlock);

        }
        LinkPath(_pathBlocks);
        RotatePath(_pathBlocks);
        AddFunctionalOnClick();
    }

    private void AddFunctionalOnClick()
    {
        for (int i = 0; i < _turretBaseBlocks.Count; i++)
        {
            TurretBaseBlock block = _turretBaseBlocks[i]; // TODO 
            _turretBaseBlocks[i].OnClick += () => _shopVisual.ShopVisual.Show(block);
        }
    }

    private void RotatePath(List<PathBlock> pathBlocks)
    {
        for (int i = 0; i < pathBlocks.Count; i++)
        {

            pathBlocks[i].transform.LookAt(pathBlocks[i].Next.transform);
            if (_pathBlocks[i].Type == PathBlock.type.L)
                if (_pathBlocks[i].Next.transform.position == _pathBlocks[i].transform.position + _pathBlocks[i].transform.forward)
                    if (_pathBlocks[i].Previous.transform.position == _pathBlocks[i].transform.position + _pathBlocks[i].transform.right)
                        _pathBlocks[i].transform.localEulerAngles += new Vector3(0, 90, 0);

            if (pathBlocks[i].Next == _endBlock) _endBlock.transform.LookAt(pathBlocks[i].transform);
        }

    }

    private void LinkPath(List<PathBlock> pathBlocks)
    {
        FindNeighbour(_startBlock, pathBlocks);
        PathBlock tempblock = (PathBlock)_startBlock.Next;
        for (int i = 0; i < pathBlocks.Count; i++)
        {
            FindNeighbour(tempblock, pathBlocks);
            if (tempblock.Next == _endBlock) return;
            tempblock = (PathBlock)tempblock.Next;
        }
    }

    //TODO
    private void FindNeighbour(PathBlock block, List<PathBlock> pathBlocks)
    {
        for (int i = 0; i < pathBlocks.Count; i++)
        {
            if (pathBlocks[i].transform.position == new Vector3(block.transform.position.x - 1, 0, block.transform.position.z) && pathBlocks[i].Next!=block)
            {
                block.Next = pathBlocks[i];
                pathBlocks[i].Previous = block;
                return;
            }
            else if(pathBlocks[i].transform.position == new Vector3(block.transform.position.x + 1, 0, block.transform.position.z) && pathBlocks[i].Next != block)
            {
                block.Next = pathBlocks[i];
                pathBlocks[i].Previous = block;
                return;
            }
            else if (pathBlocks[i].transform.position == new Vector3(block.transform.position.x, 0, block.transform.position.z+1) && pathBlocks[i].Next != block)
            {
                block.Next = pathBlocks[i];
                pathBlocks[i].Previous = block;
                return;
            }
            else if (pathBlocks[i].transform.position == new Vector3(block.transform.position.x, 0, block.transform.position.z-1) && pathBlocks[i].Next != block)
            {
                block.Next = pathBlocks[i];
                pathBlocks[i].Previous = block;
                return;
            }
            else
            {
                block.Next = _endBlock;
            }
        }
    }
}
