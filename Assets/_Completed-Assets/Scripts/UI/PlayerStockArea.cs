using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStockArea : MonoBehaviour
{
    // Shell1からShell10までのImageコンポーネント
    [SerializeField] private Image[] shellImages = new Image[10];

    // Shells10, Shells20, Shells30, Shells40のImageコンポーネント
    [SerializeField] private Image[] shellMultiplierImages = new Image[4];



    // 砲弾のストック数を更新するメソッド
    public void UpdatePlayerStockArea(int stockCount)
    {
        // Shell1からShell10の表示・非表示
        for (int i = 0; i < 10; i++)
        {
            // stockCountが1～10の間なら対応するShellを表示、そうでなければ非表示
            if (i < stockCount)
            {
                shellImages[i].gameObject.SetActive(true);
            }
            else
            {
                shellImages[i].gameObject.SetActive(false);
            }
        }

        // Shells10, Shells20, Shells30, Shells40の表示・非表示
        for (int i = 0; i < 4; i++)
        {
            // stockCountがi+1の倍数なら対応するShellMultiplierを表示
            if (stockCount >= (i + 1) * 10)
            {
                shellMultiplierImages[i].gameObject.SetActive(true);
            }
            else
            {
                shellMultiplierImages[i].gameObject.SetActive(false);
            }
        }
    }
}
