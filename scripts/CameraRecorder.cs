using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecorder : MonoBehaviour
{
    // Start is called before the first frame update

    private Material _tvMaterial;
    private int _captureCounter = 1;
    private WebCamTexture _webcamTexture;
    private const string SavePath = "C:\\Users\\alu0101408903\\Documents\\";

    void Start()
    {
        _tvMaterial = GetComponent<Renderer>().material;
        _webcamTexture = new WebCamTexture();
        Debug.Log(_webcamTexture.deviceName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            _tvMaterial.mainTexture = _webcamTexture;
            _webcamTexture.Play();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            _webcamTexture.Stop();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            Debug.Log("Capturing");
            Texture2D snapshot = new Texture2D(_webcamTexture.width, _webcamTexture.height);
            snapshot.SetPixels(_webcamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(SavePath + _captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            _captureCounter++;
        }
    }
}
