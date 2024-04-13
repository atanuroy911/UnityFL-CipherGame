using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color BaseColor, OffsetColor;
    [SerializeField] private GameObject TileHighlight;

    void OnMouseEnter()
    {
        TileHighlight.SetActive(true);
    }

    void OnMouseExit()
    {
        TileHighlight.SetActive(false);
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
