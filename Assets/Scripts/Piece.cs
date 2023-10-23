using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Vector2 pieceGridPosition;
    private GameObject pieceGameObject;

    public void SpawnPiece(){
        do{
            pieceGridPosition = SpawnRandomGridPosition();
            Instantiate(pieceGameObject, new Vector3(pieceGridPosition.x, pieceGridPosition.y, 0),Quaternion.identity);
        }while(true);
    }

    private Vector2 SpawnRandomGridPosition() {
        return new Vector2(Random.Range(0,BoardManager.BOARD_SIZE) + BoardManager.BOARD_SPACING, Random.Range(0,BoardManager.BOARD_SIZE)+BoardManager.BOARD_SPACING);
    }

    private Vector2 GetPieceGridPosition() {
        return pieceGridPosition;
    }

}
