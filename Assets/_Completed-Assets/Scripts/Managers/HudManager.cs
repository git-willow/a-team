using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class HudManager : MonoBehaviour
    {
        // Player1StockAreaとPlayer2StockAreaへの参照
        [SerializeField] private GameObject player1StockArea;
        [SerializeField] private GameObject player2StockArea;

        // GameManagerオブジェクトへの参照
        [SerializeField] private GameManager gameManager;

        private void Start()
        {
            // GameManagerのOnGameStateChangedイベントを購読
            if (gameManager != null)
            {
                gameManager.OnGameStateChanged += HandleGameStateChanged;
            }

            // GameManagerの各TankManagerのOnWeaponStockChangedイベントを購読
            foreach (var tankManager in gameManager.m_Tanks)
            {
                tankManager.OnWeaponStockChanged += HandleWeaponStockChanged;
            }
            player1StockArea.GetComponent<PlayerStockArea>().UpdatePlayerStockArea(10);
            player2StockArea.GetComponent<PlayerStockArea>().UpdatePlayerStockArea(10);
        }


        // ゲーム状態が変わったときに呼ばれるメソッド
        private void HandleGameStateChanged(GameState gameState)
        {
            // ゲームの状態に応じてHUDの表示・非表示を更新
            switch (gameState)
            {
                case GameState.RoundStarting:
                case GameState.RoundEnding:

                    // ゲーム開始または終了中はHUDを非表示
                    SetHudVisibility(false);
                    break;

                case GameState.RoundPlaying:
                    // ゲームプレイ中はHUDを表示
                    SetHudVisibility(true);
                    break;
            }
        }

        // OnWeaponStockChangedイベントを受け取った際に呼ばれるメソッド
        private void HandleWeaponStockChanged(int playerNumber, int newStock)
        {
            // プレイヤー番号に従って適切なPlayerStockAreaを更新
            if (playerNumber == 1)
            {
                player1StockArea.GetComponent<PlayerStockArea>().UpdatePlayerStockArea(newStock);
                //Debug.Log(newStock);
            }
            else if (playerNumber == 2)
            {
                player2StockArea.GetComponent<PlayerStockArea>().UpdatePlayerStockArea(newStock);
            }
        }

        // HUDの表示・非表示を切り替えるメソッド
        private void SetHudVisibility(bool isVisible)
        {
            player1StockArea.SetActive(isVisible);
            player2StockArea.SetActive(isVisible);
        }
    }
}