using System;
using UnityEngine;

public abstract class BaseBlock : MonoBehaviour
{
    private BlockState _blockState;
    public BlockState blockState
    {
        get { return _blockState; }
        set
        {
            if (_blockState != value)
            {
                _blockState = value;
                OnBlockStateChanged();
            }
        }
    }
    private void OnBlockStateChanged()
    {
        blockAnimation.SetInteger(ConstName.BLOCK_STATE, (int)blockState);
    }
    public Animator blockAnimation;
    public Board board;
    protected BaseCharacter currentPiece;
    public Transform pivot;
    public Vector2Int currentPositionInBoard;
    public void SetPiece(BaseCharacter newPiece)
    {
        currentPiece = newPiece;
    }
    public void SetPositionInBoard(int row, int column)
    {
        currentPositionInBoard = new Vector2Int(row, column);
    }
    public bool CheckLimit(int row, int column)
    {
        return row >= 0 && row < 8 && column >= 0 && column < 8;
    }
}
