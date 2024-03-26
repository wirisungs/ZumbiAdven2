using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueCharater
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharater charater;
    [TextArea(3, 10)] // tối thiểu 3 dòng, tối đa 10 dòng
    public string line;
}

[System.Serializable]
public class Dialog
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialogue()
    {
        DialogManager.Instance.OpenDialoguePanel(dialog);
    }
}
