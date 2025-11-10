using UnityEngine;
using UnityEngine.Tilemaps;
public class TilemapCopier : MonoBehaviour
{
    [Header("Source and Destination Tilemaps")]
    public Tilemap sourceTilemap;
    public Tilemap destinationTilemap;

    [ContextMenu("Copy Tilemap")]
    public void CopyTilemap()
    {
        if (sourceTilemap == null || destinationTilemap == null)
        {
            Debug.LogError("Source or Destination Tilemap is not assigned!");
            return;
        }

        destinationTilemap.ClearAllTiles();

        BoundsInt bounds = sourceTilemap.cellBounds;
        foreach (var pos in bounds.allPositionsWithin)
        {
            TileBase tile = sourceTilemap.GetTile(pos);
            if (tile != null)
            {
                destinationTilemap.SetTile(pos, tile);

                // Optional: copy tile color and transform
                destinationTilemap.SetTransformMatrix(pos, sourceTilemap.GetTransformMatrix(pos));
                destinationTilemap.SetColor(pos, sourceTilemap.GetColor(pos));
            }
        }

        destinationTilemap.RefreshAllTiles();
        destinationTilemap.CompressBounds();

        Debug.Log("Tilemap copied successfully!");
    }
}
