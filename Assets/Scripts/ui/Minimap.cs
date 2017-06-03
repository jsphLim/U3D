using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

    private Camera minimapCamera;

    void Start() {
        minimapCamera = GameObject.FindGameObjectWithTag(Tags.minimap).GetComponent<Camera>();
    }

    public void OnZoomInClick() {
        //放大
        minimapCamera.orthographicSize--;
    }
    public void OnZoomOutClick() {
        //缩小
        minimapCamera.orthographicSize++;
    }
}
