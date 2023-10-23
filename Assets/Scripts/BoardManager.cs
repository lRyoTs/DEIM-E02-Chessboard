using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public const int BOARD_SIZE = 8;
    public const float BOARD_SPACING = 0.5f;

    [SerializeField] private Sprite [] tile;
    public static BoardManager instance { get; private set;}

    public class BoardTile {
        private Vector2Int tileGridPosition;
        private bool isBusy;

        public BoardTile(Vector2Int tileGridPosition)
        {
            this.tileGridPosition = tileGridPosition;
            this.isBusy = false;
        }

        public bool IsBusy() {
            return this.isBusy;
        }

        public void SetBusy(bool state) {
            this.isBusy = state;    
        }

        public Vector2Int GetTileGridPosition() {
            return this.tileGridPosition;
        }
    }


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
        CreateBoard();
    }

    private void CreateBoard() {
        int setTileColor = 0; // 0=white 1=green
        for (int x = 0; x < BOARD_SIZE; x++) {
            
            if (setTileColor == 0)
            {
                setTileColor = 1;
            }
            else {
                setTileColor = 0;
            }
            
            for (int y = 0; y < BOARD_SIZE; y++) {
                
                CreateTile(tile[setTileColor],new Vector2(x+BOARD_SPACING,y+BOARD_SPACING));
                
                if (setTileColor == 0)
                {
                    setTileColor = 1;
                }
                else
                {
                    setTileColor = 0;
                }
            }
        }
    }

    private GameObject CreateTile(Sprite spriteColor, Vector2 gridPos) {
        GameObject tileGameObject = new GameObject("Tile",typeof(SpriteRenderer));
        SpriteRenderer tileSpriteRenderer =  tileGameObject.GetComponent<SpriteRenderer>();
        tileSpriteRenderer.sortingOrder = -1;
        tileSpriteRenderer.sprite = spriteColor;
        tileGameObject.transform.position = gridPos;
        tileGameObject.transform.parent = gameObject.transform;

        return tileGameObject;
    }
}
