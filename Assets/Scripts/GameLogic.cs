using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public List<Block> objectPredicted = new List<Block>();
    private static GameLogic instance;
    public static GameLogic Instance { get { return instance; } }
    public enum Turn
    {
        WHITE, BLACK
    }
    public BaseCharacter currentCharacter { get; private set; }
    public Turn currentTurn;
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
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        currentTurn = Turn.WHITE;
    }
    public bool IsWhiteTurn()
    {
        return currentTurn == Turn.WHITE;
    }

    public bool IsBlackTurn()
    {
        return currentTurn == Turn.BLACK;
    }
    public void ChangeTurnAutomatic()
    {
        if (currentTurn == Turn.BLACK)
        {
            currentTurn = Turn.WHITE;
        }
        else
        {
            currentTurn = Turn.BLACK;
        }
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
        ResetStateAllBlockPrediction();
        PredictionMoveStrategyContext context = new PredictionMoveStrategyContext();

        switch (character.chessPieceType)
        {
            case ChessPieceType.Pawn:
                context.SetStrategy(new PawnPredictionMoveStrategy());
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
    public void ResetStateAllBlockPrediction()
    {
        foreach (Block block in objectPredicted)
        {
            block.canReach = false;
        }
        objectPredicted.Clear();
    }
    public void SetCharacter(BaseCharacter character)
    {
        currentCharacter = character;
    }
}
