using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    //Public variables are used in very specific cases, if you need to show in the inspector, use the SerializeField property.
    //Keep this in mind also for methods, only mark them as public, if it is really needed.
    //Also initializing your variables, even to null and/or 0, you will get rid of all the warnings in the unity's console.
    [SerializeField] private List<string> myList = new List<string>();
    [SerializeField] private AudioSource[] soundNotes = null;
    [SerializeField] private GameObject[] noteDot = null;
    [SerializeField] private InputField inputNotes = null;
   
    [SerializeField] private float notesDelay = 0f;
    [SerializeField] private int counter = 0;

    [SerializeField] private AudioSource emptyAudio = null;
    [SerializeField]
    private bool testBool;
    public int getNumber;

    [SerializeField] private List<string> tempList = new List<string>();






    private void Awake()
    {
        //Use this if you want to keep your methods private, the other way is to make InputfieldToUpperCase a public method
        //and in the InputField object add an "On Value Changed" event, reference this script and call the method.

        //How you want to do it is up to you.

        //This will add a listener to the InputField and whenever you type in it, it will call InputfieldToUpperCase, so you don't have to call it every frame.
        
        //make inputnotes To UpperCase
        inputNotes.onValueChanged.AddListener(delegate { InputfieldToUpperCase(); });
        
    }

    

    void Update()
    {
        
        //Debug.Log(myList.Count - 1);
        //if (getNumber == myList.Count)
        //{
        //    var item = myList.Count;
        //    myList.Clear();
        //    getNumber = 0;
        //    //myList.FindIndex(item);
        //    Debug.Log("text " + item);

        //}
        if (Input.GetKeyDown(KeyCode.V)) //This is my personal opinion but I think it is much better to use KeyCode instead of a string.
        {
           string mystring = myList[myList.Count - 1];

        }
    }

    public void DoSomethingWithNotes()
    {
        
        //You are adding each character to a list and later you're converting it back to a string.
        //Just use the inputNotes.text inside the ReturnNotes method.
        AddsTheNotesTomyList();
        StartCoroutine(SetActiveWithString(myList));
       
    }

    public void Zempekiko()
    {
        inputNotes.text = "DSGFGFGFDSGFGSD";
    }

    void AddsTheNotesTomyList()
    {
        
        //Here makes sense to have a local variable for the ReturnNotes, so you just call it once.
        string notes = ReturnNotes();

        //adds the outputName(refers to the each letter in inputnotes field) to the List one by one
        for (int i = 0; i < notes.Length; i++)
        {
            myList.Add(notes[i].ToString());
        }

        
        for (int i = 0; i < myList.Count; i++)
        {

            //I also found a bug when checking for the "#", because if you only type, for example "C#", it gets to the first element of the list, after you add more notes it will check again the first element which contains "#", and it will try to assign to the first "element - 1" or myList[i - 1] and you'll get out of bounds. The solution is to check if the element of the list is the size of 1.
            //where the list contains #
            if (myList[i].Contains("#") && myList[i].Length == 1)
            {
                //go to the previous element and merry that together like if
                //element 1 is A and element 2 is #
                //Then it will become A#
                myList[i - 1] = myList[i - 1] + myList[i];

                //This line here just removes the # from the second element(given the example above) after is added to the list.
                myList.RemoveAt(i);
            }

        }
        myList = new List<string>();
        //getNumber += myList.Count();
        Debug.Log("Getnumber is " + getNumber) ;


    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        myList.Clear();

    }
    //Returns the notes without Space
    public string ReturnNotes()
    {
       
        string withoutSpace = "";       
        //a b cd
        foreach (var letter in inputNotes.text) 
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
        inputNotes.text = inputNotes.text.ToUpper();       
    }

    public void Clear()
    {
        //GetList.Clear(); //Not in use anymore.
        myList.Clear();
       
        inputNotes.text = "";
    }

    IEnumerator SetActiveWithString(List<string> texts)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            switch (texts[i])
            {
                
                case "C":
                    {
//                        if (noteDot[0].activeSelf)
//                        {
//                            noteDot[0].SetActive(false);
//                        }

//                        counterx++;

//#if UNITY_EDITOR //https://docs.unity3d.com/Manual/PlatformDependentCompilation.html

//                        if (counterx > 1)
//                        {
//                            Debug.Log("counterx is " + counterx);
//                        }
//#endif

                        yield return PlayNote(soundNotes[0], noteDot[0]);
                        break;
                    }
                case "S":
                    yield return PlayEmpty(emptyAudio);
                    break;
                case "D":
                    yield return PlayNote(soundNotes[1], noteDot[1]);
                    break;
                case "E":
                    yield return PlayNote(soundNotes[2], noteDot[2]);
                    break;
                case "F":
                    yield return PlayNote(soundNotes[3], noteDot[3]);
                    break;
                case "G":
                    yield return PlayNote(soundNotes[4], noteDot[4]);
                    break;
                case "G#":
                    yield return PlayNote(soundNotes[5], noteDot[10]);
                    break;
                case "A":
                    yield return PlayNote(soundNotes[6], noteDot[5]);
                    break;
                case "B":
                    yield return PlayNote(soundNotes[7], noteDot[6]);
                    break;
                case "A#":
                    yield return PlayNote(soundNotes[8], noteDot[9]);
                    break;
                case "C#":
                    yield return PlayNote(soundNotes[9], noteDot[7]);
                    break;
                case "F#":
                    yield return PlayNote(soundNotes[10], noteDot[8]);
                    break;
            }
        }

        yield return null;
    }

    private IEnumerator PlayNote(AudioSource soundNotes, GameObject noteDot)
    {
        soundNotes.Play();
        noteDot.SetActive(true);
        yield return new WaitForSeconds(notesDelay);
        noteDot.SetActive(false);
    }
    
    private IEnumerator PlayEmpty(AudioSource soundNotes)
    {
        soundNotes.Play();        
        yield return new WaitForSeconds(notesDelay);
        
    }
}