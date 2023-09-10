using UnityEngine.Tilemaps;
using UnityEngine;

public enum Tetrimino{
    I,
    S,
    Z,
    O,
    L,
    T,
    J,
}
[System.Serializable]
public struct TetriminoData{
    public Tetrimino tetrimino;
    public Tile tile;
    public Vector2Int[] cells;
}