using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    // StartButtonオブジェクトのButtonコンポーネントを参照するための変数
    [SerializeField]
    private Button startButton;

    // Startメソッド
    void Start()
    {
        // ボタンがクリックされたときにOnClickedメソッドを呼び出す
        startButton.onClick.AddListener(OnClicked);
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    private void OnClicked()
    {
        // ホーム画面へ遷移する処理
        SceneManager.LoadScene(SceneNames.HomeScene);
    }
}