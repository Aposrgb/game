using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGenerate : MonoBehaviour{
    [SerializeField]
    private GameObject buttonReference;
    [SerializeField]
    private Canvas canvas;

    int posX = 370, posY = 540;

    void Start()
    {
        var lev = SceneManager.GetSceneByName("Levels").buildIndex+1;
        var count = SceneManager.sceneCountInBuildSettings;
        int levelIndex = 1;
        for(int i = lev; i < count; i++) { 
            int j  = 0;
            j=i;
            GameObject newButton = Instantiate(buttonReference, new Vector3(posX,posY,0), Quaternion.identity);
            GameObject text = newButton.transform.GetChild(0).gameObject;
            text.GetComponent<Text>().text = ""+levelIndex;
            levelIndex++;
            newButton.GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.LoadScene(j);
            });
            newButton.transform.SetParent(canvas.transform, true);
            if(posX == 940) {
                posX = 370;
                posY -= 240;
            }
            else { 
                posX += 570;
            }
        }
    }
}
