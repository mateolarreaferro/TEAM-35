using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSequencer : MonoBehaviour
{
     public int _seconds;
    [SerializeField] GameObject [] audioObjects;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OutputTime", 1f, 1f); //Counter --> One value per second

        InvokeRepeating("Sequencer", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OutputTime()
    {
        _seconds = (int)Time.time;
    }

    void Sequencer(){

        switch(_seconds){

            case 1:
             audioObjects[0].GetComponent<AudioSource>().Play(); //Rain
             break;

            case 4:
            audioObjects[1].GetComponent<AudioSource>().Play(); //Drums
            audioObjects[2].GetComponent<AudioSource>().Play(); //Pad
            audioObjects[3].GetComponent<AudioSource>().Play(); //Bass
            break;

            case 7:                                         
            audioObjects[4].GetComponent<AudioSource>().Play(); //Bernie Sample
            break;

            case 9:
            audioObjects[5].GetComponent<AudioSource>().Play(); //Bernie Sample
            break;

            case 11:
             audioObjects[6].GetComponent<AudioSource>().Play(); //Bernie Sample
             break;

            case 12:
             
             for (int i = 0; i < audioObjects.Length; i++){

                 audioObjects[i].GetComponent<AudioSource>().Stop(); //End of Sequence

             }
             break;

        }
    }
}
