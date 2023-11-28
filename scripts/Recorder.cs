using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        foreach (var device in Microphone.devices) {
            Debug.Log("Name: " + device);
        }
        _audioSource.clip = Microphone.Start("", true, 10, 44100);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            _audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space)) Microphone.End(null);
    }
}
