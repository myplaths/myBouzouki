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
    public enum enumNotes { Default, C, D, E, F, G, A, B };
    public enumNotes myNotes;
    int num = 0;

    public GameObject testObj;
    private bool isRun;

    float timer = 3f;

    
    void Start()
    {
        myNotes = enumNotes.Default;
    }

    
    void Update()
    {

        //make inputnotes To UpperCase
        InputfieldToUpperCase();

        //if input is empty
        if (inputNotes.text == "")
        {
            //then prints default
            myNotes = enumNotes.Default;
        }//if inputnotes is the same text as the LastCharacterofMyList && isRun is false
        else if (inputNotes.text == LastCharacterofMyList.ToString() && !isRun)
        {
            CheckifMyListContains(inputNotes.text);            
            DecisionMaker();        

        }


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isRun = false;
           
        }

        if (Input.GetKeyDown("x"))
        {


            string foo = "hello world", bar = string.Empty;

            foreach (string c in myList)
            {
                bar += c;
                CheckifMyListContains(bar);
            }
                Debug.Log("this is bar " + bar);


        }

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
           
            
          
        }

       

    }

    //we check if the list contains this string and if it does then we assign the enumList it's like 
    //myNotes = enumNotes.x;
    void CheckifMyListContains(string input)
    {
        foreach (string name in Enum.GetNames(typeof(enumNotes)))
        {
            
            if (name == input)
            {
                myNotes = (enumNotes)Enum.Parse(typeof(enumNotes), name);
                Debug.Log("this is mynotes "+ myNotes);
            }
        }
    }


    

    public void DecisionMaker()
    {
        

        if (myNotes == enumNotes.Default)
        {
            Debug.Log("Default");
        }
        else if (myNotes == enumNotes.C)
        {
            Debug.Log("print C");
            StartCoroutine(SetActiveForXSeconds(noteDot[0]));
            isRun = true;
            timer = 3f;

        }
        else if (myNotes == enumNotes.D)
        {
            Debug.Log("print D");
            StartCoroutine(SetActiveForXSeconds(noteDot[1]));
            isRun = true;
            timer = 3f;

        }
        else if (myNotes == enumNotes.E)
        {
            Debug.Log("print E");
            StartCoroutine(SetActiveForXSeconds(noteDot[2]));
            isRun = true;
            timer = 3f;

        }
        else if (myNotes == enumNotes.F)
        {
            Debug.Log("print F");
            StartCoroutine(SetActiveForXSeconds(noteDot[3]));
            isRun = true;
            timer = 3f;

        }
        else if (myNotes == enumNotes.G)
        {
            Debug.Log("print G"); 
            StartCoroutine(SetActiveForXSeconds(noteDot[4]));
            isRun = true;
            timer = 3f;

        }
        else if (myNotes == enumNotes.A)
        {
            Debug.Log("print A");
            StartCoroutine(SetActiveForXSeconds(noteDot[5]));
            isRun = true;
            timer = 3f;


        }
        else if (myNotes == enumNotes.B)
        {
            Debug.Log("print B");
            StartCoroutine(SetActiveForXSeconds(noteDot[6]));
            isRun = true;
            timer = 3f;

        }

    }


    public void ReturnListItem()
    {       

        for (int i = 0; i < myList.Count; i++)
        {
            LastCharacterofMyList = myList[i];
            Debug.Log("LastCharacterofMyList is " + LastCharacterofMyList);
            
        }   

    }

    IEnumerator SetActiveForXSeconds(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(2f);
        obj.SetActive(false);

    }



    public string GrabText()
    {
        
        string x = "Default";

        switch (inputNotes.text)
        {

            case "C":
                x = inputNotes.text;
                break;
            
            case "D":
                x = inputNotes.text;
                break;
            case "E":
                x = inputNotes.text;
                break;
            case "F":
                x = inputNotes.text;
                break;
            case "G":
                x = inputNotes.text;
                break;
            case "A":
                x = inputNotes.text;
                break;
            case "B":
                x = inputNotes.text;
                break;
            default:
                Debug.Log("nothing is here");
                break;
        }

        Debug.Log("grabtext is  " + x);
        return x;
    }

 

    public void DoSomethingWithNotes()
    {
        AddInListTheInputNotesEachSeparateLetter(inputNotes.text);
        ReturnListItem();



    }

    public void Clear()
    {
        myList.Clear();
       
    }
}
