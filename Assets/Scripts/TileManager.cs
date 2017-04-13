using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject grid, turnMarker, winBanner, playAgain;
    public Tile tile;
    public Sprite spriteX, spriteO, spriteWinX, spriteWinO, spriteWinT;
    public enum TurnEnum { X, O , T};
    public TurnEnum currentTurn = TurnEnum.X;
    public Tile[,] tiles = new Tile[3, 3];
    public static TileManager tm;
    //SpriteRenderer turnMarkerSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        tm = this;
        Vector2 size = tile.GetComponent<SpriteRenderer>().size;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                tiles[x, y] = GameObject.Instantiate(tile, new Vector2(size.x * x - 1.5f, size.y * y - 2f), Quaternion.identity);
            }
        }
        Initialize();
    }

    public void Initialize()
    {
        //Initialize empty tiles

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                tiles[x, y].GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        playAgain.SetActive(false);
        turnMarker.SetActive(true);
        winBanner.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Update turn marker sprite to the current players turn
        turnMarker.GetComponent<SpriteRenderer>().sprite = currentTurn == TurnEnum.X ? spriteX : spriteO;
        bool notFull = false;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (!tiles[x, y].GetComponent<SpriteRenderer>().sprite)
                {
                    notFull = true;
                    break;
                }
            }
            if (notFull)
            {
                break;
            }
        }
        if (!notFull && !winBanner.GetComponent<SpriteRenderer>().sprite)
        {
            currentTurn = TurnEnum.T;
            onWins();
        }
    }

    public void onWins()
    {
        turnMarker.SetActive(false);
        playAgain.SetActive(true);
        switch(currentTurn)
        {
            case TurnEnum.X:
                winBanner.GetComponent<SpriteRenderer>().sprite = spriteWinO;
                break;
            case TurnEnum.O:
                winBanner.GetComponent<SpriteRenderer>().sprite = spriteWinX;   
                break;
            case TurnEnum.T:
                winBanner.GetComponent<SpriteRenderer>().sprite = spriteWinT;
                break;
            default:
                break;
        }
    }
}
