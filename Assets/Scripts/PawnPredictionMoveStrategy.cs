using UnityEngine;

public class PawnPredictionMoveStrategy : IPredictionMoveStrategy
{
    public void PredictionMove(Block block)
    {
        GameLogic.Instance.ResetStateAllBlockPrediction();

        Vector2Int newPosition = GetNextMovePosition(block);

        if (CheckLimit(newPosition.x, newPosition.y))
        {
            UpdateBlockState(Board.Instance.boardStoreBlock[newPosition.x, newPosition.y], true);
        }
    }

    private Vector2Int GetNextMovePosition(Block block)
    {
        Vector2Int position = new Vector2Int(block.positionInBoard.x, block.positionInBoard.y);
        int moveDirection = GameLogic.Instance.IsBlackTurn() ? 1 : -1;
        position.x += moveDirection;
        return position;
    }

    private void UpdateBlockState(Block block, bool canReach)
    {
        block.canReach = canReach;

        if (canReach)
        {
            GameLogic.Instance.objectPredicted.Add(block);
        }
    }
    private bool CheckLimit(int row, int column)
    {
        return row >= 0 && row < 8 && column >= 0 && column < 8;
    }
}
