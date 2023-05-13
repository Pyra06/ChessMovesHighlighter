using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        HighlightMoves highlightMoves;
        private Vector3 vector3;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            highlightMoves = new HighlightMoves();
        }

        private void Start() 
        {
            UpdatePostion();
        }

        private void Update()
        {
            UpdatePostion();
        }

        // This Method Runs WHen Chess Pieces Are Clicked
        private void OnMouseDown()
        {
            ChessBoardPlacementHandler.Instance.GetPiecePostion();
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            SendInformation();
        }
        
        // Parse Value to HighlightMoves Class
        public void SendInformation()
        {          
            highlightMoves.getPieceInformation(row, column, name);
        }

        public void UpdatePostion()
        {
            // Restrict The Input Value In Inspector Tab
            row = Mathf.Min(row, 7);
            column = Mathf.Min(column, 7);

            // Snap Our Chess Pieces To Their Respective Spots
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
        }
    }
}