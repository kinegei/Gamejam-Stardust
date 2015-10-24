using UnityEngine;
using System.Collections;

public class ChangeWorld : MonoBehaviour
{

    public int SelectedWorld = 1;
    public string ChangeWorldKey = "a";
    public int DistanceBetweenWorlds = 500;

    float debounce = 0.0f;
    float repeat = 0.4f;  // reduce to speed up auto-repeat input

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float now = Time.realtimeSinceStartup;
        if (Input.GetKey(ChangeWorldKey))
	    {
	        if (now - debounce > repeat)
	        {
	            switch (SelectedWorld)
	            {
	                case 1:
	                    SelectedWorld = 2;
	                    transform.position = new Vector3(transform.position.x, transform.position.y - DistanceBetweenWorlds,
	                        transform.position.z);
	                    break;
	                case 2:
	                    SelectedWorld = 1;
	                    transform.position = new Vector3(transform.position.x, transform.position.y + DistanceBetweenWorlds,
	                        transform.position.z);

	                    break;

                    
	            }
	            debounce = Time.realtimeSinceStartup;
                Debug.Log("SW = " + SelectedWorld);
            }
           
        }
	}
}


