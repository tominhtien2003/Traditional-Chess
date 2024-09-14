using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private static GameLogic instance;
    public static GameLogic Instance { get { return instance; } }
    public enum Turn
    {
        WHITE, BLACK
    }
    private Turn currentTurn;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Init()
    {
        currentTurn = Turn.BLACK;
    }
    public bool IsWhiteTurn()
    {
        return currentTurn == Turn.WHITE;
    }

    public bool IsBlackTurn()
    {
        return currentTurn == Turn.BLACK;
    }
    public void SetTurnWhite()
    {
        currentTurn = Turn.WHITE;
    }
    public void SetTurnBlack()
    {
        currentTurn = Turn.BLACK;
    }
    public void SelectPiece(BaseCharacter character)
    {
        MoveStrategyContext context = new MoveStrategyContext();

        switch (character.chessPieceType)
        {
            case ChessPieceType.Pawn:
                context.SetStrategy(new PawnMoveStrategy());
                break;
            case ChessPieceType.Rook:

                break;
            case ChessPieceType.Bishop:
                break;
            case ChessPieceType.Queen:
                break;
            case ChessPieceType.Knight:
                break;
            case ChessPieceType.King:
                break;
            default:
                break;
        }

        context.ExecutePredictionMove(character.currentBlock);
    }
}
