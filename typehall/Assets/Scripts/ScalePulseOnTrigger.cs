using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePulseOnTrigger : MonoBehaviour
{
    public float pulsePerSecond = 3f;
    public Vector3 fullPulseScale = Vector3.one;
    Transform _trans;
    Vector3 _startScale;
    public bool pulsing;
    float timer = 0;
    float i = 0;

    void Start()
    {
        _trans = transform;
        _startScale = transform.localScale;
        //pulsing = true;
        //enabled = false;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand"))
        {
            if (pulsing)
                return;
            pulsing = true;
            timer = 0;
            i = 0;
        }
    }

    void Update()
    {
        
        if (pulsing)
        {
            timer += Time.deltaTime;
            if (timer >= 1f / pulsePerSecond)
            {
                pulsing = false;
                _trans.localScale = _startScale;
                return;
            }

            i += Time.deltaTime * pulsePerSecond;
            _trans.localScale = Vector3.Lerp(_startScale, fullPulseScale, Mathf.PingPong(i * 2, 1));
        }
    }
}
