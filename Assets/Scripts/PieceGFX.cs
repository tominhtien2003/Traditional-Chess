using UnityEngine;

public class PieceGFX : MonoBehaviour
{
    private BaseCharacter logicCharacter;
    private void Start()
    {
        logicCharacter = GetComponentInParent<BaseCharacter>();
        //Debug.Log(logicCharacter!=null);
    }
    private void OnMouseDown()
    {
        GameLogic.Instance.SelectPiece(logicCharacter);
    }
}
