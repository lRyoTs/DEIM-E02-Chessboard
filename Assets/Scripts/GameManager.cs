using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }

    private float spawnMaxTimer = 1f;
    private float spawnTimer;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than 1 instances of Game Manager");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BoardManager.instance.AllTilesBusy())
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnMaxTimer)
            {
                spawnTimer -= spawnMaxTimer;
                Piece piece = new Piece();
            }
        }
        else {
            Debug.Log("GAME FINISHED");
        }

    }
}
