using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public Button resultsButton;

    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        resultsButton.gameObject.SetActive(false);
        resultText.text = "";
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (CannonScript.instance.itemsFired >= 8 && sceneName == "CannonScene2")
        {
            resultsButton.gameObject.SetActive(true);
        }
    }

    public void ShowResults()
    {
        resultText.text = "Casualties: " + CannonScript.instance.timesFired;
    }
}
