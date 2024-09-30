using System.Collections;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    public ChessPieceType chessPieceType;
    public ChessSide chessSide;
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
    public void MoveToTarget(Block targetBlock)
    {
        currentBlock.SetPiece(null);
        targetBlock.SetPiece(this);
        StartCoroutine(MoveToTargetCoroutine(targetBlock));
    }
    private IEnumerator MoveToTargetCoroutine(Block targetBlock)
    {
        Vector3 startPosition = currentBlock.pivot.transform.position;
        Vector3 targetPosition = targetBlock.pivot.transform.position;
        startPosition.y = targetPosition.y = transform.position.y;
        float totalDistance = Vector3.Distance(startPosition, targetPosition);
        float elapsedTime = 0f;

        while (elapsedTime < totalDistance / moveSpeed)
        {
            //Debug.Log(elapsedTime);
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime * moveSpeed / totalDistance);
            elapsedTime += Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }
        transform.position = targetPosition;

        Debug.Log(transform.position);

        GameLogic.Instance.ChangeTurnAutomatic();
    }
}
