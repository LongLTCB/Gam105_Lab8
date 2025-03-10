using UnityEngine;

public class PlayerControllero : MonoBehaviour
{
    AudioSource _do, _re, _mi, _fa, _sol, _la, _si;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(message: "Start");
        _do = GameObject.FindWithTag("do").GetComponent<AudioSource>();
        _re = GameObject.FindWithTag("re").GetComponent<AudioSource>();
        _mi = GameObject.FindWithTag("mi").GetComponent<AudioSource>();
        _fa = GameObject.FindWithTag("fa").GetComponent<AudioSource>();
        _sol = GameObject.FindWithTag("son").GetComponent<AudioSource>();
        _la = GameObject.FindWithTag("la").GetComponent<AudioSource>();
        _si = GameObject.FindWithTag("si").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(message: "Press A");
            _do.Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(message: "Press D");
            _re.Play();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log(message: "Getkey A");
            _mi.Play();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log(message: "Getkey D");
            _fa.Play();
        }
    }
}
