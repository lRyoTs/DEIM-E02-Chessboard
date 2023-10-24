using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public const int BOARD_SIZE = 8;
    public const float BOARD_SPACING = 0.5f;
    public List<BoardTile> tileList;

    public static BoardManager instance { get; private set;}

    private void Awake()
    {
        if (instance != null) {
            Debug.LogError("There is more than 1 instance of BoardManager");
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<BoardTile>();
        CreateBoard();
    }

    private void CreateBoard() {
        for (int y = 0; y < BOARD_SIZE; y++) {
                        
            for (int x = 0; x < BOARD_SIZE; x++) {
                
                CreateTile(GameAssets.Instance.tileColorSprite[(x+y)%2],new Vector2(x+BOARD_SPACING,y+BOARD_SPACING));
            }
        }
    }

    private BoardTile CreateTile(Sprite spriteColor, Vector2 gridPos) {

        BoardTile newTile = new BoardTile(gridPos,spriteColor);
        newTile.SetParent(gameObject.transform);
        tileList.Add(newTile);
        return newTile;
    }

    public bool AllTilesBusy() {
        foreach (BoardTile tile in tileList) {
            if (!tile.IsBusy()) {
                return false;
            }
        }
        return true;
    }
}
