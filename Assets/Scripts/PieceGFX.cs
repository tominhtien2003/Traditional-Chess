using UnityEngine;

public class PieceGFX : MonoBehaviour
{
    private BaseCharacter logicCharacter;
    private void Start()
    {
        logicCharacter = GetComponentInParent<BaseCharacter>();
        //Debug.Log(logicCharacter == null);
    }
    private void OnMouseDown()
    {
        if (CanPress())
        {
            if (GameLogic.Instance.currentCharacter != logicCharacter)
            {
                GameLogic.Instance.SetCharacter(logicCharacter);
            }
            GameLogic.Instance.SelectPiece(logicCharacter);
        }

    }
    private bool CanPress()
    {
        if (logicCharacter == null)
        {
            Debug.Log("NuLL");
        }
        return (GameLogic.Instance.IsBlackTurn() && logicCharacter.chessSide == ChessSide.BLACK) ||
                (GameLogic.Instance.IsWhiteTurn() && logicCharacter.chessSide == ChessSide.WHITE);
    }
}
