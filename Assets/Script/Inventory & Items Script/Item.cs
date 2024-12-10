using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    private bool isInteract;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found! Check if InventoryCanvas has the InventoryManager script attached.");
        }
        isInteract = false;
    }
    private void Update()
    {
        if(isInteract && Input.GetButtonDown("Interact"))
        {
            Debug.Log("item is collected");
            inventoryManager.AddItem(itemName, sprite);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            isInteract = true;
            Debug.Log("Player is getting in the zone");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isInteract = false;
            Debug.Log("Player is getting away");
        }
    }
}
