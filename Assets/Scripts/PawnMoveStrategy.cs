
using UnityEngine;

public class PawnMoveStrategy : IPredictionMoveStrategy
{
    public void PredictionMove(Block block)
    {
        Vector2Int positionInBoard = new Vector2Int(block.currentPositionInBoard.x, block.currentPositionInBoard.y);

        int moveDirection = GameLogic.Instance.IsBlackTurn() ? -1 : 1;

        positionInBoard.x += moveDirection;
        if (block.CheckLimit(positionInBoard.x, positionInBoard.y))
        {
            block.board.boardStoreBlock[positionInBoard.x, positionInBoard.y].blockState = BlockState.SELECTED;
        }
    }
}
