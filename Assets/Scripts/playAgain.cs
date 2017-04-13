using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAgain : MonoBehaviour
{
    private void OnMouseDown()
    {
        TileManager.tm.Initialize();
    }
}
