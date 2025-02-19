using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    // moves for the knight
    private static readonly Vector2Int[] moveOffsets = 
    {
        new Vector2Int(2, 1),  new Vector2Int(2, -1),
        new Vector2Int(-2, 1), new Vector2Int(-2, -1),
        new Vector2Int(1, 2),  new Vector2Int(1, -2),
        new Vector2Int(-1, 2), new Vector2Int(-1, -2)
    };

    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Check each possible move for the knight
        foreach (Vector2Int offset in moveOffsets)
        {
            Vector2Int newPosition = new Vector2Int(boardPosition.x + offset.x, boardPosition.y + offset.y);
            if (IsWithinBoard(newPosition))
            {
                ChessPiece targetPiece = boardState[newPosition.x, newPosition.y];
                if (targetPiece == null || targetPiece.isWhite != this.isWhite)
                    validMoves.Add(newPosition); // Valid move if empty or enemy piece not blocking
            }
        }

        return validMoves;
    }
    // makes sure moves are within board space
    private bool IsWithinBoard(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }
}
