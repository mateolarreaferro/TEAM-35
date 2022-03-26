using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //Makes sure there is an AS attached
public class SingleHit : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip [] _clips;

    [SerializeField] bool isReversing = false;

    
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
           // SelectAndPlay();

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("hand")){
            SelectAndPlay();

        }
    }

    void SelectAndPlay(){
        _source.clip = _clips[(int)UnityEngine.Random.Range(0, _clips.Length)];

        int probability = (int)UnityEngine.Random.Range(1, 10);

        if (probability > 2){

            _source.pitch = 1.0f;
        }
        else if (probability <= 2){

            _source.pitch = -1.0f;
        }



        _source.Play();
    }
}
