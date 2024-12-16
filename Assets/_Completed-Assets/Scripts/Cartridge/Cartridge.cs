using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public float lifeTime = 10f;            // ���݂��鎞��
    public float blinkDuration = 2f;       // ���ł��J�n���鎞��
    public float blinkInterval = 0.2f;     // ���ŊԊu

    private Renderer cartridgeRenderer;    // Renderer�R���|�[�l���g

    private void Start()
    {
        // Renderer�R���|�[�l���g���擾
        cartridgeRenderer = GetComponent<Renderer>();

        // lifeTime-blonkDuration�b�o�߂����疾�ł��J�n
        Invoke(nameof(StartBlinking), lifeTime - blinkDuration);

        // lifeTime���o�߂�����J�[�g���b�W������
        Destroy(gameObject, lifeTime);
    }

    private void StartBlinking()
    {
        InvokeRepeating(nameof(Blink), 0f, blinkInterval);
    }

    private void Blink()
    {
        if (cartridgeRenderer != null)
        {
            // Renderer��L��/�����ɂ���
            cartridgeRenderer.enabled = !cartridgeRenderer.enabled;
        }
    }

    private void OnDestroy()
    {
        // ���ł��~
        CancelInvoke(nameof(Blink));
    }
}
