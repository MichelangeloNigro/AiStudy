using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private List<Camera> allCameras;
    private Camera currentCamera;
    // Start is called before the first frame update
    void Start() {
        allCameras = FindObjectsOfType<Camera>(true).ToList();
        currentCamera = FindObjectOfType<Camera>(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            currentCamera.enabled = false;
            currentCamera = allCameras[(allCameras.IndexOf(currentCamera) + 1)%allCameras.Count];
            currentCamera.enabled = true;
        }
    }
}
