using System;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] List<Block> blockList;
    [SerializeField] LayerMask blockMask;
    public Block currentBlock;
    [SerializeField] Block blockStartPoint;
    public Block[,] boardStoreBlock = new Block[8, 8];
    private void Start()
    {
        BuildArray2D();
    }
    private void BuildArray2D()
    {
        Block currentRowBlock = blockStartPoint;
        int row = 0;

        while (currentRowBlock != null && row < 8)
        {
            Block currentColumnBlock = currentRowBlock;
            int col = 0;

            while (currentColumnBlock != null && col < 8)
            {
                boardStoreBlock[row, col] = currentColumnBlock;

                currentColumnBlock.SetPositionInBoard(row, col);

                //Debug.Log($"Block at [{row}, {col}] is {currentColumnBlock.name}");

                //Debug.DrawRay(currentColumnBlock.pivot.position, -Vector3.forward, Color.red, 1f);

                if (Physics.Raycast(currentColumnBlock.pivot.position, -Vector3.forward, out RaycastHit hitInfo, 1f, blockMask))
                {
                    currentColumnBlock = hitInfo.collider.GetComponentInParent<Block>();
                }
                else
                {
                    currentColumnBlock = null;
                }

                col++;
            }

            if (Physics.Raycast(currentRowBlock.pivot.position, Vector3.right, out RaycastHit rowHitInfo, 1f, blockMask))
            {
                currentRowBlock = rowHitInfo.collider.GetComponentInParent<Block>();
            }
            else
            {
                currentRowBlock = null;
            }

            row++;
        }
    }
    public Block GetBlockAtPosition(int row, int col)
    {
        if (row >= 0 && row < 8 && col >= 0 && col < 8)
        {
            return boardStoreBlock[row, col];
        }
        else
        {
            Debug.LogWarning("Invalid position.");
            return null;
        }
    }
}
