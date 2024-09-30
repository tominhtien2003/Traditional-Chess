using UnityEngine;

public abstract class BaseBlock : MonoBehaviour
{
    public Transform buttonPanel;
    public Animator blockAnimation { get; set; }
    [SerializeField] GameObject targetedObject;
    public BaseCharacter currentPiece { get; private set; }
    public Transform pivot;
    public Vector2Int positionInBoard;

    private BlockState _blockState;
    private bool _canReach;

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
    public bool canReach
    {
        get { return _canReach; }
        set
        {
            if (_canReach != value)
            {
                _canReach = value;
                OnValidCanReachChange();
            }
        }
    }
    private void OnValidCanReachChange()
    {
        targetedObject.SetActive(canReach);
        if (!canReach)
        {
            buttonPanel.gameObject.SetActive(false);
            blockState = BlockState.NORMAL;
            Board.Instance.currentBlock = null;
        }
    }
    private void OnBlockStateChanged()
    {
        if ((int)blockState < 2)
        {
            SetAnimationWhenBlockStateChanged();
            if (canReach)
            {
                buttonPanel.gameObject.SetActive(blockState == BlockState.SELECTED);
            }
        }
    }
    private void SetAnimationWhenBlockStateChanged()
    {
        if (blockAnimation != null)
        {
            blockAnimation.SetInteger(ConstName.BLOCK_STATE, (int)blockState);
        }
        else
        {
            Debug.Log("Block Animation is null");
        }
    }
    public void SetPiece(BaseCharacter newPiece)
    {
        currentPiece = newPiece;
    }

    public void SetPositionInBoard(int row, int column)
    {
        positionInBoard = new Vector2Int(row, column);
    }
}
