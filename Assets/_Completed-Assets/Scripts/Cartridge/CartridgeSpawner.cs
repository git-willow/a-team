using Complete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Complete
{
    public class CartridgeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject shellCartridgePrefab; // ShellCartridgeのプレハブ
        [SerializeField] private GameObject gameManagerObj;  // GameManagerオブジェクトへの参照
        private GameManager gameManager;

        [SerializeField] private Vector2 spawnAreaSize = new Vector2(10f, 10f); // 生成エリアの範囲
        [SerializeField] private float spawnHeight = 1f; // 生成位置の高さ

        [SerializeField] private float spawnInterval = 5f; // 生成間隔

        private void Start()
        {
            // GameManagerのインスタンスを取得
            gameManager = gameManagerObj.GetComponent<GameManager>();

            if (gameManagerObj != null)
            {
                // GameManagerのイベントを購読
                gameManager.OnGameStateChanged += HandleGameStateChanged;
            }
        }

        // ゲーム状態変更時の処理
        private void HandleGameStateChanged(GameState newState)
        {
            // ゲームがプレイ中の時だけコルーチンを開始
            if (newState == GameState.RoundPlaying)
            {
                StartCoroutine(SpawnRoutine());  // プレイ中のときだけSpawnRoutineを開始
            }
            else
            {
                StopCoroutine(SpawnRoutine());  // ゲーム終了または開始中は停止
            }
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                SpawnCartridge(); // プレハブを生成
                yield return new WaitForSeconds(spawnInterval); // 指定した時間待機
            }
        }

        public void SpawnCartridge()
        {
            // ランダムな位置を計算
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                spawnHeight,
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
            );

            // プレハブを生成
            Instantiate(shellCartridgePrefab, randomPosition, Quaternion.identity);
        }
    }
}
