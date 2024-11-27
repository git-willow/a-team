using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VersusPlayerButton : MonoBehaviour
{
    [SerializeField]
    private Button button2;

    // Start is called before the first frame update
    void Start()
    {
        button2.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        SceneManager.LoadScene(SceneNames.scene2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
