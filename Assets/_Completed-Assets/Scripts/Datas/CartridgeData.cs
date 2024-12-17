using System.Collections;
using UnityEngine;

[System.Serializable]
public class CartridgeData 
{
    // カートリッジのプレハブの参照
    public GameObject cartridgePrefab;

    // カートリッジの生成位置
    public Transform spawnPosition;

    // カートリッジの生成頻度（秒単位）
    public float spawnFrequency;

}