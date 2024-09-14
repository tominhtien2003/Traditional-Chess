using System;
using System.Collections;
using UnityEngine;

public class BlockGFX : MonoBehaviour
{
    private Block block;
    private bool isAnimating;

    private void Awake()
    {
        block = GetComponentInParent<Block>();
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
        // Kiểm tra xem block hiện tại có được chọn không và có phải là block hiện tại của board không
        return block.board.currentBlock == null || block.board.currentBlock == block;
    }

    private void ToggleBlockState()
    {
        switch (block.blockState)
        {
            case BlockState.NORMAL:
                block.board.currentBlock = block;
                block.blockState = BlockState.SELECTED;
                break;

            case BlockState.SELECTED:
                block.board.currentBlock = null;
                block.blockState = BlockState.NORMAL;
                break;
        }
    }

    private IEnumerator WaitForAnimationToEnd()
    {
        isAnimating = true;

        // Đợi cho đến khi animation kết thúc và không còn trong quá trình chuyển tiếp
        AnimatorStateInfo stateInfo;
        do
        {
            stateInfo = block.blockAnimation.GetCurrentAnimatorStateInfo(0);
            yield return null;
        } while (stateInfo.normalizedTime < 1 || block.blockAnimation.IsInTransition(0));

        isAnimating = false;
    }
}
