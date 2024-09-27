using UnityEngine;

public class Board : MonoBehaviour
{
    private static Board instance;
    public static Board Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] LayerMask blockMask;
    public Block currentBlock { get; set; }
    [SerializeField] Block blockStartPoint;
    public Block[,] boardStoreBlock = new Block[8, 8];
    private void Start()
    {
        BuildBoard();
    }
    private void BuildBoard()
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
}
