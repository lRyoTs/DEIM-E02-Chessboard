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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
