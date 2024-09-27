using UnityEngine;

public class PieceGFX : MonoBehaviour
{
    private BaseCharacter logicCharacter;
    private void Start()
    {
        logicCharacter = GetComponentInParent<BaseCharacter>();
    }
    private void OnMouseDown()
    {
        if (logicCharacter != GameLogic.Instance.currentCharacter)
        {
            GameLogic.Instance.currentCharacter = logicCharacter;
        }
        else
        {
            Debug.Log("Piece was selected");
            return;
        }
        if (CanPress())
        {
            GameLogic.Instance.SelectPiece(logicCharacter);
        }
    }
    private bool CanPress()
    {
        return (GameLogic.Instance.IsBlackTurn() && logicCharacter.chessSide == ChessSide.BLACK) ||
                (GameLogic.Instance.IsWhiteTurn() && logicCharacter.chessSide == ChessSide.WHITE);
    }
}
