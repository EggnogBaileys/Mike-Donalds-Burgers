using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public Dialogue dialogueBox;
    public GameObject physicalBox;
    public string[] dialogue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < dialogue.Length; i++)
            {
                dialogueBox.dialogue[i] = dialogue[i];
            }
            physicalBox.SetActive(true);
            dialogueBox.StartDialogue();
        }
    }
}
