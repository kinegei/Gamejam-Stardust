using UnityEngine;
using System.Collections;
using UnityEditor.VersionControl;

public class SeedTree : MonoBehaviour
{

    public GameObject TreeToSpawn;
    private GameObject SpawnetTree;
    public GameObject Seed;
    public int SeedWorld = 1;
    public float DistanseBetweenWorlds = 500.29f;
    public float DiffX = 0.5f;

    private bool ThreeShowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (SeedWorld == 2 && !ThreeShowing)
	    {
	        Debug.Log("Skal spawne tree");
	        ThreeShowing = true;
            SpawnetTree = (GameObject)Instantiate(TreeToSpawn, transform.position, transform.rotation);
            SpawnetTree.transform.position = new Vector3(Seed.transform.position.x+DiffX, Seed.transform.position.y+ DistanseBetweenWorlds, Seed.transform.position.z);
	        Debug.Log("Spawnet treet");
	    }else if (SeedWorld == 1 && ThreeShowing)
	    {
	        Destroy(SpawnetTree);
	        ThreeShowing = false;
	    }

       
	}


    public void ChangeWorld()
    {
        
    }
}
