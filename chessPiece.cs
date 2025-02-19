// This script needs to be added to each chess piece object's prefab in unity

using UnityEngine;
using System.Collections.Generic;

// base class for all chess pieces
public abstract class ChessPiece : MonoBehaviour
{
    // Indicates if the piece is white (true) or black (false)
    public bool isWhite;

    // Stores the piece's position on the chessboard as a 2D grid coordinate
    public Vector2Int boardPosition;

    // Each chess piece will override this method to define its valid moves
    public abstract List<Vector2Int> GetValidMoves(ChessPiece[,] boardState);

    // Moves the piece to a new board position
    public virtual void Move(Vector2Int newPosition)
    {
        boardPosition = newPosition; // Updates the piece's position
        transform.position = ChessBoard.Instance.GetWorldPosition(newPosition); // Updates the visual position
    }
}
