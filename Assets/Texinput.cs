using UnityEngine;
using System.Collections;

public class Texinput : MonoBehaviour {
    public UITextList text;
    private UIInput input;
    // Use this for initialization
    private string[] names = new string[3]{
        "系统:",
        "哲哥哥:",
        "文源:"
    };


	void Awake () {
        //text = this.GetComponent<UITextList>();
        input = this.GetComponent<UIInput>();
	}
	public void Ontextchange()
    {
        string message = input.value;
        string name = names[Random.Range(0, 3)];
        text.Add(name+message);
        input.value = "";
    }
	
}
