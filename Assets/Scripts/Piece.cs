using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    private Vector2 pieceGridPosition;
    private GameObject pieceGameObject;

    public Piece() {
        SpawnPiece();
    }

    public void SpawnPiece(){
        //Search for an free tile
        do
        {
            pieceGridPosition = SpawnRandomGridPosition();
        } while (!BoardManager.instance.IsTileBusy(pieceGridPosition));

        //Spawn object in the free tile
        pieceGameObject = new GameObject("Piece");
        SpriteRenderer foodSpriteRenderer = pieceGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.pieceSprite;
        pieceGameObject.transform.position = new Vector3(pieceGridPosition.x, pieceGridPosition.y, 0);
    }

    private Vector2 SpawnRandomGridPosition() {
        return new Vector2(Random.Range(0,BoardManager.BOARD_SIZE) + BoardManager.BOARD_SPACING, Random.Range(0,BoardManager.BOARD_SIZE)+BoardManager.BOARD_SPACING);
    }

    public Vector2 GetPieceGridPosition() {
        return pieceGridPosition;
    }
}
