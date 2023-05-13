using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
// Additon To Code
using System.Collections.Generic;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour {
    [SerializeField] public GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab, _highlightEnemyPrefab;
    private GameObject[,] _chessBoard;

    // Addition To Code
    public GameObject[] chessPieces;
    [HideInInspector] public List<Vector3> piecePositions;

    internal static ChessBoardPlacementHandler Instance;

    private void Awake() {
        Instance = this;
        GenerateArray();
    }

    private void Start()
    {
        piecePositions = new List<Vector3>();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j) {
        try {
            return _chessBoard[i, j];
        } catch (Exception) {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col) {
        var tile = GetTile(row, col).transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform) {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }

    // Addition To Code
    internal void HighlightEnemy(int row, int col)
    {
        var tile = GetTile(row, col).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }

        // Assigns The Red Sprite To Enemy Tile
        Instantiate(_highlightEnemyPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    // Addition To Code
    internal void GetPiecePostion()
    {
        piecePositions.Clear();

        // For Every Time A Piece Is Clicked Or The Postion Of Any Piece Changes All Piece's Coordinate Gets Updated Here
        foreach (GameObject chessPiece in chessPieces)
        {
            piecePositions.Add(chessPiece.transform.position);
        }
    }

    #region Highlight Testing

    /*    private void Start() {
            StartCoroutine(Testing());
        }

        private IEnumerator Testing() {
            Highlight(2, 7);
            yield return new WaitForSeconds(1f);

            ClearHighlights();
            Highlight(2, 7);
            Highlight(2, 6);
            Highlight(2, 5);
            Highlight(2, 4);
            yield return new WaitForSeconds(1f);

            ClearHighlights();
            Highlight(7, 7);
            Highlight(2, 7);
            yield return new WaitForSeconds(1f);
        }*/

    #endregion
}