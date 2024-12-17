using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class HudManager : MonoBehaviour
    {
        // Player1StockArea��Player2StockArea�ւ̎Q��
        [SerializeField] private GameObject player1StockArea;
        [SerializeField] private GameObject player2StockArea;

        // GameManager�I�u�W�F�N�g�ւ̎Q��
        [SerializeField] private GameManager gameManager;

        private void Start()
        {
            // GameManager��OnGameStateChanged�C�x���g���w��
            if (gameManager != null)
            {
                gameManager.OnGameStateChanged += HandleGameStateChanged;
            }

            // GameManager�̊eTankManager��OnWeaponStockChanged�C�x���g���w��
            foreach (var tankManager in gameManager.m_Tanks)
            {
                tankManager.OnWeaponStockChanged += HandleWeaponStockChanged;
            }
            player1StockArea.GetComponent<PlayerStockArea>().UpdatePlayerStockArea(10);
            player2StockArea.GetComponent<PlayerStockArea>().UpdatePlayerStockArea(10);
        }


        // �Q�[����Ԃ��ς�����Ƃ��ɌĂ΂�郁�\�b�h
        private void HandleGameStateChanged(GameState gameState)
        {
            // �Q�[���̏�Ԃɉ�����HUD�̕\���E��\�����X�V
            switch (gameState)
            {
                case GameState.RoundStarting:
                case GameState.RoundEnding:

                    // �Q�[���J�n�܂��͏I������HUD���\��
                    SetHudVisibility(false);
                    break;

                case GameState.RoundPlaying:
                    // �Q�[���v���C����HUD��\��
                    SetHudVisibility(true);
                    break;
            }
        }

        // OnWeaponStockChanged�C�x���g���󂯎�����ۂɌĂ΂�郁�\�b�h
        private void HandleWeaponStockChanged(int playerNumber, int newStock)
        {
            // �v���C���[�ԍ��ɏ]���ēK�؂�PlayerStockArea���X�V
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

        // HUD�̕\���E��\����؂�ւ��郁�\�b�h
        private void SetHudVisibility(bool isVisible)
        {
            player1StockArea.SetActive(isVisible);
            player2StockArea.SetActive(isVisible);
        }
    }
}