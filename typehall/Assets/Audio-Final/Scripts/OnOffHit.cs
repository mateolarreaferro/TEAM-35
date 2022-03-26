using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //Makes sure there is an AS attached

    public class OnOffHit : MonoBehaviour

{
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip [] _clips;

    [SerializeField] bool isReversing = false;



    
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = true;
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("hand")){
            //Debug.Log("uwu");

            if (_source.isPlaying){
                _source.Stop();
            }
            else {
                SelectAndPlay();
            }

        }
    }

    void SelectAndPlay(){
        _source.clip = _clips[(int)UnityEngine.Random.Range(0, _clips.Length)];

        if (isReversing){
            _source.pitch = -1.0f;
        }
        else {
            _source.pitch = 1.0f;
        }
        
        _source.Play();
    }
}
