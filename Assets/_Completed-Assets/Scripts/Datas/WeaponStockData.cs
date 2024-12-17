using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  // これを追加
public class WeaponStockData
{
    [SerializeField] private int initialMineCount = 5;  // 地雷の所持数の初期値
    [SerializeField] private int maxMineCount = 10;     // 所持できる地雷の最大値
    [SerializeField] private int mineRefillAmount = 3;  // 地雷カートリッジを取得した時に補充する数
    // 地雷の所持数が変化した時に発生するイベント
    //public event Action<int> OnMineStockChanged;

    //[SerializeField] private WeaponStockData weaponStockData;
    private int currentMineCount;  // 現在の所持地雷数を格納するprivate変数

    private void Start()
    {
        // 初期値で所持している地雷の数を設定
        currentMineCount = initialMineCount;
    }

    // 現在の地雷の所持数を返すgetterメソッド
    public int GetCurrentMineCount()
    {
        return currentMineCount;
    }

    // 現在所持数を初期化するメソッド
    public void ResetMineCount()
    {
        currentMineCount = initialMineCount;
        Debug.Log("地雷の所持数が初期化されました: " + currentMineCount);
    }

    // 現在の所持数を増やすメソッド（最大値を超えないようにする）
    public void IncreaseMineCount(int amount)
    {
        currentMineCount = Mathf.Min(currentMineCount + amount, maxMineCount);
        Debug.Log("地雷の所持数が増加しました: " + currentMineCount);

        // 所持数が変化した時にイベントを発火
        //OnMineStockChanged?.Invoke(GetCurrentMineCount);
    }

    // 現在の所持数をデクリメントするメソッド（ゼロを下回らないようにする）
    public void DecreaseMineCount(int amount)
    {
        currentMineCount = Mathf.Max(currentMineCount - amount, 0);
        Debug.Log("地雷の所持数が減少しました: " + currentMineCount);

        // 所持数が変化した時にイベントを発火
        //OnMineStockChanged?.Invoke(GetCurrentMineCount);
    }

    // 地雷を補充するメソッド（カートリッジを取得した時に使う）
    public void RefillMines()
    {
        currentMineCount = Mathf.Min(currentMineCount + mineRefillAmount, maxMineCount);
        Debug.Log("地雷の補充後: " + currentMineCount);

        // 所持数が変化した時にイベントを発火
        //OnMineStockChanged?.Invoke(GetCurrentMineCount);
    }

}

