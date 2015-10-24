using System;
using UnityEngine;
using System.Collections.Generic;

public class MoveToWorld : MonoBehaviour
{

    public string TakeToWorldKey = "s";
    public float TimeToTeleport = 0.5f;
    public int DistanceBetweenWorlds = 500;
    public int SelectedWorld = 1;

    public GameObject Player;

    private bool _keyHeld = false;
    private Single _startTime;
    private Inventory _inventory;
    private readonly List<GameObject> _objectsToMove = new List<GameObject>();



    public Sprite NewBackground;
    public Sprite Oldbackground;
    public GameObject bakgrunn;


    

	// Use this for initialization
	void Start ()
	{
	    _inventory = Player.GetComponent<Inventory>();

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(TakeToWorldKey))
	    {
	        if (!_keyHeld)
	        {
	            _startTime = Time.realtimeSinceStartup;
	        }
	        _keyHeld = true;
	    }
	    else
	    {
	        _keyHeld = false;
	    }


	    if (_keyHeld && (_startTime + TimeToTeleport) < Time.realtimeSinceStartup)
	    {
	        _keyHeld = false;
            var b = bakgrunn.GetComponent<SpriteRenderer>();
            switch (SelectedWorld)
            {
                case 1:
                    SelectedWorld = 2;
                    MoveObjects(-DistanceBetweenWorlds, SelectedWorld);
                    transform.position = new Vector3(transform.position.x, transform.position.y - DistanceBetweenWorlds,
                    transform.position.z);
                    b.sprite = Oldbackground;
                    break;
                case 2:
                    SelectedWorld = 1;
                    MoveObjects(DistanceBetweenWorlds, SelectedWorld);
                    transform.position = new Vector3(transform.position.x, transform.position.y + DistanceBetweenWorlds,
                    transform.position.z);
                    b.sprite = NewBackground;
                    
                    break;
            }
        }
	}

    private void MoveObjects(int pos, int world)
    {
        foreach (var o in _objectsToMove)
        {
            var prop = o.GetComponent<TransportableProperties>();
            if (prop != null)
            {
                if (prop.PowerRequiredToTransport < _inventory.SparklePower)
                {
                    o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + pos,
                        o.transform.position.z);
                    SeedTreeTransform(o, world);
                }
            }
        }
    }

    private void SeedTreeTransform(GameObject o, int world)
    {
        try
        {
            var t = o.GetComponent<SeedTree>();

            t.SeedWorld = world;

        }
        catch (Exception)
        {
            
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Transportable")
        {
            if (!_objectsToMove.Contains(other.gameObject))
            {
                _objectsToMove.Add(other.gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (_objectsToMove.Contains(other.gameObject))
        {
            _objectsToMove.Remove(other.gameObject);
        }
    }
}
