using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VersusPlayerButton : MonoBehaviour
{
    // StartButtonオブジェクトのButtonコンポーネントを参照するための変数
    [SerializeField]
    private Button versusPlayerButton;

    // Startメソッド
    void Start()
    {
        // ボタンがクリックされたときにOnClickedメソッドを呼び出す
        versusPlayerButton.onClick.AddListener(OnClicked);
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnClicked()
    {
        // ホーム画面へ遷移する処理
        SceneManager.LoadScene(SceneNames.GameScene);
    }
}
