using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void ButtonAgreeMove()
    {
        Block targetBlock = Board.Instance.currentBlock;
        GameLogic.Instance.ResetStateAllBlockPrediction();
        GameLogic.Instance.currentCharacter.MoveToTarget(targetBlock);
    }
    public void ButtonRefuseMove()
    {
        ResetCurrentBlockInBoard();
    }
    private void ResetCurrentBlockInBoard()
    {
        Board.Instance.currentBlock.blockState = BlockState.NORMAL;
        Board.Instance.currentBlock = null;
    }
}
