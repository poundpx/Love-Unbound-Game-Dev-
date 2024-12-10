using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    //Item Data
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;

    //Item Slot
    [SerializeField]
    private Image itemImage;

    private void Awake()
    {
        // Automatically find the Image component on this GameObject
        itemImage = GetComponentInChildren<Image>();

        if (itemImage == null)
        {
            Debug.LogError("No Image component found on ItemSlot or its children.");
        }
    }
    public void AddItem(string itemName, Sprite itemSprite)
    {
        if (itemImage == null)
        {
            Debug.LogError("Item image not assigned in ItemSlot! Please assign it in the Inspector.");
            return;
        }

        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;
        itemImage.sprite = itemSprite; // Update the UI image
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
