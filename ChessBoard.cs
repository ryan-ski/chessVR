using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public static ChessBoard Instance; // global access
    public GameObject chessPiecePrefab; // Prefab for chess pieces
    public Transform boardCenter; // Reference for board positioning
    public ChessPiece[,] boardState = new ChessPiece[8, 8]; // Stores the chessboard state

    private void Awake()
    {
        Instance = this; // single instance, access is global
    }

    // Converts 2D board coordinates to 3D world space
    public Vector3 GetWorldPosition(Vector2Int boardPosition)
    {
        float tileSize = 0.25f; 
        return boardCenter.position + new Vector3(boardPosition.x * tileSize, 0, boardPosition.y * tileSize);
    }

    public void SetupBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            SpawnPiece(new Pawn(), new Vector2Int(i, 1), true); // Spawn white pawns
            SpawnPiece(new Pawn(), new Vector2Int(i, 6), false); // Spawn black pawns
        }
    }

    void SpawnPiece(ChessPiece piece, Vector2Int position, bool isWhite)
    {
        ChessPiece newPiece = Instantiate(chessPiecePrefab, GetWorldPosition(position), Quaternion.identity).GetComponent<ChessPiece>();
        newPiece.isWhite = isWhite;
        newPiece.boardPosition = position;
        boardState[position.x, position.y] = newPiece; // Store in board array
    }
}
