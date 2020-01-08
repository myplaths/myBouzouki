using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    List<string> GetList = new List<string>();
    public List<string> myList = new List<string>();

    public InputField inputNotes;
    public GameObject[] noteDot;
    public string LastCharacterofGetList;
    public float notesDelay;

    public int counterx = 0;
    public AudioSource[] soundNotes;

    


    void Update()
    {

        //make inputnotes To UpperCase
        InputfieldToUpperCase();


        if (Input.GetKeyDown("v"))
        {
           

        }



    }
    void AddsTheNotesTomyList()
    {
        //adds the outputName(refers to the each letter in inputnotes field) to the List one by one
        for (int i = 0; i < ReturnNotes().Length; i++)
        {
            myList.Add(ReturnNotes()[i].ToString());
            
        }
        for (int i = 0; i < myList.Count; i++)
        {
           //where the list contains #
            if (myList[i].Contains("#"))
            {
                //go to the previous element and merry that together like if 
                //element 1 is A and element 2 is #
                //Then it will become A#
                myList[i - 1] = myList[i-1] + myList[i];

                //This line here just removes the # from the second element(given the example above) after is added to the list.
                myList.RemoveAt(i);
            }
        }
    }

    //Returns the notes without Space
    public string ReturnNotes()
    {
         string outputName = "";
        string withoutSpace = ""; 
        
        //first we use the outputname to add the whole list into one string
        for (int i = 0; i < GetList.Count; i++)
        {
            outputName += GetList[i];
        }

        //removes the space from the outputName so something like A B C it converts it to ABC
        foreach (var letter in outputName)
        {
            if (letter == ' ')
            {
                continue;
            }
            withoutSpace += letter;
        }        
       
        return withoutSpace;
    }

    //this method just makes the Inputfield to UpperCase
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
            GetList.Add(x[i].ToString());          

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
                soundNotes[0].Play();
                noteDot[0].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[0].SetActive(false);


            }
            else if (texts[i] == "D")
            {
                soundNotes[1].Play();
                noteDot[1].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[1].SetActive(false);
            }
            else if (texts[i] == "E")
            {
                soundNotes[2].Play();
                noteDot[2].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[2].SetActive(false);
            }
            else if (texts[i] == "F")
            {
                soundNotes[3].Play();
                noteDot[3].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[3].SetActive(false);
            }
            else if (texts[i] == "G")
            {
                soundNotes[4].Play();
                noteDot[4].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[4].SetActive(false);
            }if (texts[i] == "G#")
            {
                soundNotes[5].Play();
                noteDot[10].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[10].SetActive(false);
            }
            else if (texts[i] == "A")
            {
                soundNotes[6].Play();
                noteDot[5].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[5].SetActive(false);
            }
            else if (texts[i] == "B")
            {
                soundNotes[7].Play();
                noteDot[6].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[6].SetActive(false);
            }
            else if (texts[i] == "A#")
            {
                soundNotes[8].Play();
                noteDot[9].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[9].SetActive(false);
            }
            else if (texts[i] == "C#")
            {
                soundNotes[9].Play();
                noteDot[7].SetActive(true);
                yield return new WaitForSeconds(notesDelay);
                noteDot[7].SetActive(false);
            }
            else if (texts[i] == "F#")
            {
                soundNotes[10].Play();
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
        AddsTheNotesTomyList();
        StartCoroutine(SetActiveWithString(myList));
        
    }

    public void Clear()
    {
        GetList.Clear();
        myList.Clear();
        counterx = 0;

    }
}