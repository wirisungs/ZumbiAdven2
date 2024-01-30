using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public InteractionManager InteractionManager;
    public GameObject dialoguePanel;
    public GameObject continueBtn;
    public Text dialogueText;
    public string[] dialogue;
    public bool isTyping;

    private float wordSpeed = 0.01f;
    private int index;

    // Update is called once per frame
    void Update()
    {
        InteractionManager.InteractButton();
        if(dialogueText.text == dialogue[index])
            continueBtn.SetActive(true);
    }

    public void OpenDialoguePanel()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            ZeroText();
        }
        else
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
            isTyping = true;
        }
    }
    public void onButtonClick()
    {
        OpenDialoguePanel();
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void NextLine()
    {
        continueBtn.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
            isTyping = false;
        }
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}
