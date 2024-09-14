using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    public ChessPieceType chessPieceType;
    public LayerMask blockMask;
    public float moveSpeed;
    public float jumpForce;
    public Block currentBlock;
    protected void GetCurrentBlock()
    {
        try
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, .5f, blockMask))
            {
                Block block = hitInfo.collider.GetComponentInParent<Block>();

                if (block != null)
                {
                    block.SetPiece(this);
                    SetBlock(block);
                }
                else
                {
                    Debug.LogWarning("The current block is not a valid Block instance.");
                }
            }
            else
            {
                SetBlock(null);
                Debug.LogWarning("No block found under the Pawn.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    public void SetBlock(Block newBlock)
    {
        currentBlock = newBlock;
    }
}
