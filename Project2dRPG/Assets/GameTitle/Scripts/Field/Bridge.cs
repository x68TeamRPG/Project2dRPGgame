using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>水面に橋をかけて通行可能にする。タイルマップの親にアタッチ</summary>
public class Bridge : MonoBehaviour
{
    [SerializeField] Tilemap waterMap;//水面のタイルマップ。TilemapCollider2D必須
    [SerializeField] Tilemap objectsMap;//橋などがあるタイルマップ
    [SerializeField] TileBase[] bridgeTiles;//橋(通行可能)タイル

    // Start is called before the first frame update
    void Start()
    {
        waterMap.GetComponent<TilemapCollider2D>().enabled = false;//表示用のタイルマップの衝突判定はOFF
        Tilemap waterMap2 = Instantiate(waterMap, transform);//当たり判定専用のタイルマップを追加

        foreach (Vector3Int pos in objectsMap.cellBounds.allPositionsWithin)//橋などがあるタイルマップの全マスを調査
        {
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            if (waterMap2.HasTile(cellPosition))//当たり判定専用のタイルマップの該当位置に水面(当たり判定あり)のタイルがあれば
            {
                foreach (TileBase tile in bridgeTiles)
                {
                    if (objectsMap.GetTile(cellPosition) == tile)//橋があれば
                    {
                        waterMap2.SetTile(cellPosition, null);//当たり判定専用のタイルマップから水面タイルを消去
                        break;
                    }
                }
            }
        }

        waterMap2.GetComponent<TilemapCollider2D>().enabled = true;//当たり判定専用のタイルマップの当たり判定ON
        waterMap2.GetComponent<TilemapRenderer>().enabled = false;//当たり判定専用のタイルマップを非表示にする
    }
}