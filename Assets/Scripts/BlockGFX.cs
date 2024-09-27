using System.Collections;
using UnityEngine;

public class BlockGFX : MonoBehaviour
{
    private Block logicBlock;
    private bool isAnimating;

    private void Awake()
    {
        logicBlock = GetComponentInParent<Block>();
    }
    private void OnMouseDown()
    {
        if (isAnimating || !CanChangeState())
        {
            return;
        }
        ToggleBlockState();
        StartCoroutine(WaitForAnimationToEnd());
    }
    private bool CanChangeState()
    {
        return Board.Instance.currentBlock == null || Board.Instance.currentBlock == logicBlock;
    }
    private void ToggleBlockState()
    {
        switch (logicBlock.blockState)
        {
            case BlockState.NORMAL:
                Board.Instance.currentBlock = logicBlock;
                logicBlock.blockState = BlockState.SELECTED;
                break;

            case BlockState.SELECTED:
                Board.Instance.currentBlock = null;
                logicBlock.blockState = BlockState.NORMAL;
                break;
            default:
                Debug.Log("BlockState is error");
                break;
        }
    }

    private IEnumerator WaitForAnimationToEnd()
    {
        isAnimating = true;
        AnimatorStateInfo stateInfo;
        do
        {
            stateInfo = logicBlock.blockAnimation.GetCurrentAnimatorStateInfo(0);
            yield return null;
        } while (stateInfo.normalizedTime < 1 || logicBlock.blockAnimation.IsInTransition(0));

        isAnimating = false;
    }
}
