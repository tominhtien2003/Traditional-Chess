using UnityEngine;

public class Pawn : BaseCharacter
{
    private void Start()
    {
        chessPieceType = ChessPieceType.Pawn;
        GetCurrentBlock();
    }
}
