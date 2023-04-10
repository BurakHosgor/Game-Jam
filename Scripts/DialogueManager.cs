using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    private float typingSpeed = 0.04f;
    private Coroutine displayLineCoroutine;


    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue){

        Debug.Log("Starting the Conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence (){

        if (sentences.Count == 0)
        {   
            StartCoroutine(EndDialogue());
            return;
        }

        string sentence = sentences.Dequeue();

        //if pressed continue, stop the first coroutine
        if(displayLineCoroutine != null){

            StopCoroutine(displayLineCoroutine);
        }

        displayLineCoroutine = StartCoroutine(DisplayLine(sentence));
    }


    //Makes the sentence like typing
    private IEnumerator DisplayLine(string line){

        dialogueText.text = "";

        foreach(char letter in line.ToCharArray()){

            //if a player wants to skip but read the  sentence, 
            //if pressed space => dialougeText.text = line;  break;

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

    }

    //End of conversation, close the dialouge panel
    private IEnumerator EndDialogue(){

        Debug.Log("bitti konuşma aga");
        yield return new WaitForSeconds(2.3f);

        dialoguePanel.SetActive(false);

    }


}
