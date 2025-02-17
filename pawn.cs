using System.Collections.Generic;
using UnityEngine;

// The Pawn piece inherits from ChessPiece
public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetValidMoves(ChessPiece[,] boardState)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Determines movement direction based on piece color white pieces move up (1), black pieces move down (-1)
        int direction = isWhite ? 1 : -1;

        // Check if moving forward one square is allowed
        Vector2Int forwardMove = new Vector2Int(boardPosition.x, boardPosition.y + direction);
        if (boardState[forwardMove.x, forwardMove.y] == null)
            validMoves.Add(forwardMove); // Add to valid moves if a piece is not blocking it

        return validMoves;
    }
}
