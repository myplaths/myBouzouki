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
   

    public GameObject testObj;
 

    
    void Start()
    {
        
    }

    
    void Update()
    {

        //make inputnotes To UpperCase
        InputfieldToUpperCase();

    
        if (Input.GetKeyDown("v"))
        {
           
                
        }



    }

   

    void InputfieldToUpperCase()
    {
        string text = inputNotes.text;
        if (text != inputNotes.text.ToUpper())
        {
            inputNotes.text = inputNotes.text.ToUpper();
        }
    }

    public void AddInListTheInputNotesEachSeparateLetter(string x)
    {
        
        for (int i = 0; i < x.Length; i++)
        {

            myList.Add(x[i].ToString());

            Debug.Log("test");

        }       

    }
    
   

    IEnumerator SetActiveWithString(List<string> texts)
    {

        for (int i = 0; i < texts.Count; i++)
        {
            if (texts[i] == "C")
            {
                noteDot[0].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[0].SetActive(false);
            }else if (texts[i] == "D")
            {
                noteDot[1].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[1].SetActive(false);
            }else if (texts[i] == "E")
            {
                noteDot[2].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[2].SetActive(false);
            }else if (texts[i] == "F")
            {
                noteDot[3].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[3].SetActive(false);
            }else if (texts[i] == "G")
            {
                noteDot[4].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[4].SetActive(false);
            }else if (texts[i] == "A")
            {
                noteDot[5].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[5].SetActive(false);
            }else if (texts[i] == "B")
            {
                noteDot[6].SetActive(true);
                yield return new WaitForSeconds(2f);
                noteDot[6].SetActive(false);
            }
        }

        yield return null;
    }


    public void DoSomethingWithNotes()
    {
        AddInListTheInputNotesEachSeparateLetter(inputNotes.text);
        for (int i = 0; i < myList.Count; i++)
        {
            StartCoroutine(SetActiveWithString(myList));
        }

    }

    public void Clear()
    {
        myList.Clear();
       
    }
}
