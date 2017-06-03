using UnityEngine;
using System.Collections;

public class Tex : MonoBehaviour {
    public UITextList text;
	// Use this for initialization
	void Awake () {
        text = this.GetComponent<UITextList>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            text.Add("jinzhongzhizhuwannsui!!!");
        }
	}
}
