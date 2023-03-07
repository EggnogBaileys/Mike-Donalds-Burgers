using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] dialogue; // compilation of lines of dialogue
    public float textspeed;

    int line = 0; // which line of dialogue should display


    // Create functions that basically run through several lines.
    // Other scripts would reference specific functions from within this DialogueBox and call lines from it



    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        //StartDialogue();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        LineClick();

        if (dialogue[line] == "")
        {
            gameObject.SetActive(false);
        }
    }

    void LineClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == dialogue[line])
            {
                Nextline();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogue[line];
            }
        }
    }

    public void StartDialogue()
    {
        line = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Type each character 1 by 1
        foreach (char c in dialogue[line].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void Nextline()
    {
        if (line < dialogue.Length - 1)
        {
            line++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }



}
