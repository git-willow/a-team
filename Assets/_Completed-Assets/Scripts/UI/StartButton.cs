using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private Button button1;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        SceneManager.LoadScene(SceneNames.scene1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}