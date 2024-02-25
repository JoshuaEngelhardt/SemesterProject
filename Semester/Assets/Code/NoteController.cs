using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteController : MonoBehaviour
{
   public string code;
    public TMP_Text uiText;
    public GameObject uiPanel;

    private bool isShowingText = false;

    void Start()
    {
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Interact()
    {
        //if(Input.GetKeyUp(KeyCode.E)) {
            if (isShowingText == true)
            {
                uiPanel.SetActive(false);
                isShowingText = false;
            }
            else
            {
                uiPanel.SetActive(true);
                uiText.text = code;
                isShowingText = true;
            }
        //}
    }
}
