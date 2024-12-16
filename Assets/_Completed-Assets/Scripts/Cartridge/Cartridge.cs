using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public float lifeTime = 10f;            // 存在する時間
    public float blinkDuration = 2f;       // 明滅を開始する時間
    public float blinkInterval = 0.2f;     // 明滅間隔

    private Renderer cartridgeRenderer;    // Rendererコンポーネント

    private void Start()
    {
        // Rendererコンポーネントを取得
        cartridgeRenderer = GetComponent<Renderer>();

        // lifeTime-blonkDuration秒経過したら明滅を開始
        Invoke(nameof(StartBlinking), lifeTime - blinkDuration);

        // lifeTimeが経過したらカートリッジを消滅
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
            // Rendererを有効/無効にする
            cartridgeRenderer.enabled = !cartridgeRenderer.enabled;
        }
    }

    private void OnDestroy()
    {
        // 明滅を停止
        CancelInvoke(nameof(Blink));
    }
}
