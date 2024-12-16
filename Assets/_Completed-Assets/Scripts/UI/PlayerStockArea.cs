using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStockArea : MonoBehaviour
{
    // Shell1����Shell10�܂ł�Image�R���|�[�l���g
    [SerializeField] private Image[] shellImages = new Image[10];

    // Shells10, Shells20, Shells30, Shells40��Image�R���|�[�l���g
    [SerializeField] private Image[] shellMultiplierImages = new Image[4];



    // �C�e�̃X�g�b�N�����X�V���郁�\�b�h
    public void UpdatePlayerStockArea(int stockCount)
    {
        // Shell1����Shell10�̕\���E��\��
        for (int i = 0; i < 10; i++)
        {
            // stockCount��1�`10�̊ԂȂ�Ή�����Shell��\���A�����łȂ���Δ�\��
            if (i < stockCount)
            {
                shellImages[i].gameObject.SetActive(true);
            }
            else
            {
                shellImages[i].gameObject.SetActive(false);
            }
        }

        // Shells10, Shells20, Shells30, Shells40�̕\���E��\��
        for (int i = 0; i < 4; i++)
        {
            // stockCount��i+1�̔{���Ȃ�Ή�����ShellMultiplier��\��
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
