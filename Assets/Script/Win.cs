using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public Text text;
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            text.text = "YOU WIN DUDE";
            

        }
    }
}
