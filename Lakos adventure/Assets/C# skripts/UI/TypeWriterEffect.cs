using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    private bool isCoroutineRunning;
    [SerializeField] private textinteractor Texter;
    [SerializeField] private PlayerMovemont player;
    [SerializeField] private playerinteract ineracor;
    [SerializeField] public Animator anim;

    void Start()
    {
        Texter.textboxinsceene = this;
        Texter.box = gameObject;
        gameObject.SetActive(false);
    }

    IEnumerator ShowText()
    {
        
        isCoroutineRunning = true; // bool so it is possible to stop from the outside
        int i = 0;
        while (i <= fullText.Length && isCoroutineRunning) // loop through the full text, changed to while loop as it is easier to break from the outside
        {
            currentText = fullText.Substring(0, i); // add next character to the string
            GetComponentInChildren<TMP_Text>().text = currentText; // show/save to textbox
            if (currentText[^Mathf.Min(2, currentText.Length)..] == ". ") // compares the last 2 added and if it is correct == ". " there will be an extra wait time
            {
                yield return new WaitForSeconds(delay * 10);
                Debug.Log(i);
            }
            yield return new WaitForSeconds(delay); // wait to print letters
            i++;
        }
        isCoroutineRunning = false;
    }

    public void UpdateFullText()
    {

        if (isCoroutineRunning == true)
        {
            isCoroutineRunning = false;

            GetComponentInChildren<TMP_Text>().text = fullText;
        }
        else
        {
            ineracor.enabled = true;
            player.enabled = true;
            anim.SetTrigger("continue");
            gameObject.SetActive(false);

        }
    }



    public void CallUpdateFullText(string str)
    {
        ineracor.enabled = false;
        player.enabled = false;
        fullText = str;
        StartCoroutine(ShowText()); // the new line to load, TODO: make list or document with lines
    }
}
