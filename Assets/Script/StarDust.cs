using UnityEngine;
using System.Collections;

public class StarDust : MonoBehaviour {

    public GameObject Self;
    private Inventory inventory;

    public int StarPowerAmount = 20;

    void Start()
    {
        var obj = GameObject.Find("Player");
        inventory = obj.GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(Self);
            inventory.SparklePower += StarPowerAmount;
        }
    }
}
