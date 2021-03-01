using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;

    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;

    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of DialogueManager");
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentSentenceToDisplay = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentenceToDisplay));
    }
    
    IEnumerator TypeSentence(string currentSentenceToDisplay)
    {
        dialogueText.text = "";
        foreach (char letter in currentSentenceToDisplay.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
