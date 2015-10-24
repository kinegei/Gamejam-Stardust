using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveToWorld : MonoBehaviour
{

    public string TakeToWorldKey = "s";
    public int TimeToTeleport = 2;
    public int DistanceBetweenWorlds = 500;
    public int SelectedWorld = 1;

    public GameObject Player;

    private bool keyHeld = false;
    private Single startTime;
    private Inventory inventory;
    private List<GameObject> objectsToMove = new List<GameObject>(); 


    

	// Use this for initialization
	void Start ()
	{
	    inventory = Player.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(TakeToWorldKey))
	    {
	        if (!keyHeld)
	        {
	            startTime = Time.realtimeSinceStartup;
	        }
	        keyHeld = true;
	    }
	    else
	    {
	        keyHeld = false;
	    }


	    if (keyHeld && (startTime + TimeToTeleport) < Time.realtimeSinceStartup)
	    {
	        keyHeld = false;
            switch (SelectedWorld)
            {
                case 1:
                    SelectedWorld = 2;
                    transform.position = new Vector3(transform.position.x, transform.position.y - DistanceBetweenWorlds,
                    transform.position.z);
                    MoveObjects(-DistanceBetweenWorlds);
                    break;
                case 2:
                    SelectedWorld = 1;
                    transform.position = new Vector3(transform.position.x, transform.position.y + DistanceBetweenWorlds,
                    transform.position.z);
                    MoveObjects(DistanceBetweenWorlds);
                    break;
            }
        }
	}

    private void MoveObjects(int pos)
    {
        foreach (var o in objectsToMove)
        {
            var prop = o.GetComponent<TransportableProperties>();
            if (prop != null)
            {
                if(prop.PowerRequiredToTransport < inventory.SparklePower)
                    o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + pos, o.transform.position.z);
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Transportable")
        {
            if (!objectsToMove.Contains(other.gameObject))
            {
                objectsToMove.Add(other.gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (objectsToMove.Contains(other.gameObject))
        {
            objectsToMove.Remove(other.gameObject);
        }
    }
}
