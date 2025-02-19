using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public static ChessBoard Instance; // global access
    public GameObject chessPiecePrefab; // Prefab for chess pieces Need to assign the prefab in unity in the heiarchy for models, scripts and colider
    public Transform boardCenter; // Reference for board positioning
    public ChessPiece[,] boardState = new ChessPiece[8, 8]; // Stores the chessboard state

    private void Awake()
    {
        Instance = this; // single instance, access is global
    }

    // Converts 2D coordinates to 3D world space
    public Vector3 GetWorldPosition(Vector2Int boardPosition)
    {
        float tileSize = 0.25f; 
        return boardCenter.position + new Vector3(boardPosition.x * tileSize, 0, boardPosition.y * tileSize);
    }

    // creates chess pieces at positions
    public void SetupBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            SpawnPiece(new Pawn(), new Vector2Int(i, 1), true); // Spawn white pawns
            SpawnPiece(new Pawn(), new Vector2Int(i, 6), false); // Spawn black pawns
        }
        // this is where we add the other pieces to spawn
    }

    void SpawnPiece(ChessPiece piece, Vector2Int position, bool isWhite)
    {
        ChessPiece newPiece = Instantiate(chessPiecePrefab, GetWorldPosition(position), Quaternion.identity).GetComponent<ChessPiece>(); // Quaternion = no rotation keeps objects still
        newPiece.isWhite = isWhite; 
        newPiece.boardPosition = position;
        boardState[position.x, position.y] = newPiece; // Store in board array
    }
}
