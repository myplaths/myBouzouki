using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public InputField inputNotes;
    public GameObject[] noteDot;
    public List<string> myList = new List<string>();
    public string LastCharacterofMyList;
    public float notesDelay;

    public int counterx = 0;
    public string outputName;
    public string withoutSpace;

    void Update()
    {

        //make inputnotes To UpperCase
        InputfieldToUpperCase();

    
        if (Input.GetKeyDown("v"))
        {
           
                
        }



    }

    public void RemoveEmptySpace()
    {
        for (int i = 0; i < myList.Count; i++)
        {
            outputName += myList[i];
        }

        foreach (var letter in outputName)
        {
            if (letter == ' ')
            {
                continue;
            }
            withoutSpace += letter;
        }

        Debug.Log("its called");
        string text = inputNotes.text;
        //outputName.Trim();
    }

    void InputfieldToUpperCase()
    {
        string text = inputNotes.text;
        if (text != inputNotes.text.ToUpper())
        {
            inputNotes.text = inputNotes.text.ToUpper();
            
        }
    }

    //this method adds in a list each letter
    public void AddInListTheInputNotesEachSeparateLetter(string x)
    {
        
        for (int i = 0; i < x.Length; i++)
        {
            myList.Add(x[i].ToString());

            if (x[i] == '#')
            {               
                
                myList[i-1]=(x[i-1].ToString() + x[i]);
                if (x[i] == '#')
                {

                    myList[i] = "";

                }
                
            }

        }

    }
    
   

    IEnumerator SetActiveWithString(List<string> texts)
    {
       
        for (int i = 0; i < texts.Count; i++)
        {
            if (texts[i] == "C")
            {
                if (noteDot[0].activeSelf)
                {
                    noteDot[0].SetActive(false);
                }
                counterx++;
                if (counterx > 1)
                {
                    Debug.Log("counterx is " + counterx);
                }
               
                noteDot[0].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[0].SetActive(false);
               

            }
            else if (texts[i] == "D")
            {
                noteDot[1].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[1].SetActive(false);
            }else if (texts[i] == "E")
            {
                noteDot[2].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[2].SetActive(false);
            }else if (texts[i] == "F")
            {
                noteDot[3].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[3].SetActive(false);
            }else if (texts[i] == "G")
            {
                noteDot[4].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[4].SetActive(false);
            }else if (texts[i] == "A")
            {
                noteDot[5].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[5].SetActive(false);
            }else if (texts[i] == "B")
            {
                noteDot[6].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[6].SetActive(false);
            }else if (texts[i] == "A#")
            {
                noteDot[9].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[9].SetActive(false);
            }else if (texts[i] == "C#")
            {
                noteDot[7].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[7].SetActive(false);
            }else if (texts[i] == "F#")
            {
                noteDot[8].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[8].SetActive(false);
            }
        }

        yield return null;
    }


    public void DoSomethingWithNotes()
    {
        AddInListTheInputNotesEachSeparateLetter(inputNotes.text);
       
            StartCoroutine(SetActiveWithString(myList));
        RemoveEmptySpace();



    }

    public void Clear()
    {
        myList.Clear();
        counterx = 0;
       
    }
}
