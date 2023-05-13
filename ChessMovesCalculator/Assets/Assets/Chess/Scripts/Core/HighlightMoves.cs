using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightMoves : MonoBehaviour
{
    private int rowHolder, columnHolder;
    private string nameHolder;
    private bool obstacle = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Store The Coordinates And Name Of Chess Piece Thats Clicked
    public void getPieceInformation(int row, int column, string piece)
    {
        rowHolder = row;
        columnHolder = column;
        nameHolder = piece;
        pieceCheck();
    }

    // Choose Between Different Functions Based On The Piece That Was Clicked
    public void pieceCheck()
    {
        Dictionary<string, Action<int, int>> pieceMoves = new Dictionary<string, Action<int, int>>
        {
            { "King", kingMoves },
            { "Queen", queenMoves },
            { "Bishop", bishopMoves },
            { "Knight", knightMoves },
            { "Rook", rookMoves },
            { "Pawn", pawnMoves }
        };

        if (pieceMoves.ContainsKey(nameHolder))
        {
            pieceMoves[nameHolder](rowHolder, columnHolder);
        }
    }

    // Selects All Possible Tiles For King
    private void kingMoves(int rowCoordinates, int columnCoordinates)
    {
        checkMove(rowCoordinates - 1, columnCoordinates); // Down
        checkMove(rowCoordinates - 1, columnCoordinates + 1); // Down-Right
        checkMove(rowCoordinates, columnCoordinates + 1); // Right
        checkMove(rowCoordinates + 1, columnCoordinates + 1); // Up-Right
        checkMove(rowCoordinates + 1, columnCoordinates); // Up
        checkMove(rowCoordinates + 1, columnCoordinates - 1); // Up-Left
        checkMove(rowCoordinates, columnCoordinates - 1); // Left
        checkMove(rowCoordinates - 1, columnCoordinates - 1); // Down-Left
    }

    // Selects All Possible Tiles For Queen
    private void queenMoves(int rowCoordinates, int columnCoordinates)
    {
        // Up
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates + i, columnCoordinates);
            }
        }

        // Down
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates - i, columnCoordinates);
            }
        }

        // Right
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates, columnCoordinates + i);
            }
        }

        // Left
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates, columnCoordinates - i);
            }
        }

        // Down-Left Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates - i, columnCoordinates - i);
            }
        }

        // Down-Right Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates - i, columnCoordinates + i);
            }
        }

        // Up-Left Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates + i, columnCoordinates - i);
            }
        }

        // Up-Right Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates + i, columnCoordinates - i);
            }
        }
    }

    // Selects All Possible Tiles For Bishop
    private void bishopMoves(int rowCoordinates, int columnCoordinates)
    {
        // Down-Left Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates - i, columnCoordinates - i);
            }
        }

        // Down-Right Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates - i, columnCoordinates + i);
            }
        }

        // Up-Left Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates + i, columnCoordinates - i);
            }
        }

        // Up-Right Diagonal
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates + i, columnCoordinates + i);
            }
        }
    }

    // Selects All Possible Tiles For Pawn
    private void pawnMoves(int rowCoordinates, int columnCoordinates)
    {
        if (ChessBoardPlacementHandler.Instance._rowsArray[1].transform.position.y == ChessBoardPlacementHandler.Instance.GetTile(rowCoordinates, columnCoordinates).transform.position.y)
        {
            checkPawnMove(rowCoordinates + 1, columnCoordinates); // Up-1
            if (!obstacle)
            {
                checkPawnMove(rowCoordinates + 2, columnCoordinates); // Up-2
            }
        }
        else
        {
            checkPawnMove(rowCoordinates + 1, columnCoordinates); // Up-1
        }

        checkPawnEnemy(rowCoordinates + 1, columnCoordinates + 1); // Up-Right
        checkPawnEnemy(rowCoordinates + 1, columnCoordinates - 1); // Up-Left
    }

    // Selects All Possible Tiles For Rook
    private void rookMoves(int rowCoordinates, int columnCoordinates)
    {
        // Up
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates + i, columnCoordinates);
            }
        }

        // Down
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates - i, columnCoordinates);
            }
        }

        // Right
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates, columnCoordinates + i);
            }
        }

        // Left
        obstacle = false;
        for (int i = 1; i < 8; i++)
        {
            if (obstacle)
            {
                break;
            }
            else
            {
                checkMove(rowCoordinates, columnCoordinates - i);
            }
        }
    }

    // Selects All Possible Tiles For Knight
    private void knightMoves(int rowCoordinates, int columnCoordinates)
    {
        checkMove(rowCoordinates + 2, columnCoordinates + 1); // L Top-Right
        checkMove(rowCoordinates + 1, columnCoordinates + 2); // L Right-Top
        checkMove(rowCoordinates - 1, columnCoordinates + 2); // L Right-Bottom
        checkMove(rowCoordinates - 2, columnCoordinates + 1); // L Bottom-Right
        checkMove(rowCoordinates - 2, columnCoordinates - 1); // L Bottom-Left
        checkMove(rowCoordinates - 1, columnCoordinates - 2); // L Left-Bottom
        checkMove(rowCoordinates + 1, columnCoordinates - 2); // L Left-Top
        checkMove(rowCoordinates + 2, columnCoordinates - 1); // L Top-Left
    }

    // A Common Method To Check the Availability Of The Tile Thats Parsed
    public void checkMove(int rowVerify, int colVerify)
    {
        // To verify that the moves are within 8x8 cells
        if (rowVerify >= 0 && rowVerify < 8 && colVerify >= 0 && colVerify < 8)
        {
            Vector3 movePosition = ChessBoardPlacementHandler.Instance.GetTile(rowVerify, colVerify).transform.position;

            // Keeps Track Of Availability
            bool isMoveLegal = true;

            // Check Whether Their Is Some Other Piece On Pathway Or Not
            foreach (Vector3 piecePosition in ChessBoardPlacementHandler.Instance.piecePositions)
            {
                if (movePosition == piecePosition)
                {
                    obstacle = true;
                    for (int i = 0; i < 19; i++)
                    {
                        // If That Piece Is Of Enemy The Highlight Gets Turned Red
                        if (piecePosition == ChessBoardPlacementHandler.Instance.chessPieces[i].transform.position && ChessBoardPlacementHandler.Instance.chessPieces[i].CompareTag("EnemyChessPieces"))
                        {
                            ChessBoardPlacementHandler.Instance.HighlightEnemy(rowVerify, colVerify);
                        }
                    }

                    // If That Piece Is Of Same Side Then The Trail For Open Path Stops
                    isMoveLegal = false;
                    break;
                }
            }

            // If There Is No Piece On The Pathway The Highlight Gets Turned Into Green
            if (isMoveLegal)
            {
                ChessBoardPlacementHandler.Instance.Highlight(rowVerify, colVerify);
            }
        }
    }

    // Functionality Is Similar To CheckMove, These Both Are Personalized Methods for Different Cases Of Pawn
    public void checkPawnMove(int rowVerify, int colVerify)
    {
        // To verify that the moves are within 8x8 cells
        if (rowVerify >= 0 && rowVerify < 8 && colVerify >= 0 && colVerify < 8)
        {
            Vector3 movePosition = ChessBoardPlacementHandler.Instance.GetTile(rowVerify, colVerify).transform.position;

            bool isMoveLegal = true;

            foreach (Vector3 piecePosition in ChessBoardPlacementHandler.Instance.piecePositions)
            {
                if (movePosition == piecePosition)
                {
                    obstacle = true;
                    isMoveLegal = false;
                    break;
                }
            }

            if (isMoveLegal)
            {
                ChessBoardPlacementHandler.Instance.Highlight(rowVerify, colVerify);
            }
        }
    }
    public void checkPawnEnemy(int rowVerify, int colVerify)
    {
        // To verify that the moves are within 8x8 cells
        if (rowVerify >= 0 && rowVerify < 8 && colVerify >= 0 && colVerify < 8)
        {
            Vector3 movePosition = ChessBoardPlacementHandler.Instance.GetTile(rowVerify, colVerify).transform.position;

            foreach (Vector3 piecePosition in ChessBoardPlacementHandler.Instance.piecePositions)
            {
                if (movePosition == piecePosition)
                {
                    for (int i = 0; i < 19; i++)
                    {
                        if (piecePosition == ChessBoardPlacementHandler.Instance.chessPieces[i].transform.position && ChessBoardPlacementHandler.Instance.chessPieces[i].CompareTag("EnemyChessPieces"))
                        {
                            ChessBoardPlacementHandler.Instance.HighlightEnemy(rowVerify, colVerify);
                        }
                    }
                    break;
                }
            }
        }
    }
}