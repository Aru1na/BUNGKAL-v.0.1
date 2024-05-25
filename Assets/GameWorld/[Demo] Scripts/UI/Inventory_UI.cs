using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public Player player;
    public GameObject inventoryPanel;
    public List<Slots_UI> slots = new List<Slots_UI>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {   
            ToggleInventory();
        }
    }
    public void ToggleInventory(){
        if (!inventoryPanel.activeSelf){
            inventoryPanel.SetActive(true);
            Setup();
        }else{
            inventoryPanel.SetActive(false);
        }
    }

    public void closeInventory(){
        inventoryPanel.SetActive(false);
    }

    void Setup(){
        for (int x = 0; x<player.compiler.artifactNew.Count; x++){
            if (player.compiler.artifactNew[x].type != CollectableType.NONE){
                slots[x].SetItem(player.compiler.artifactNew[x]);
            } else {
                slots[x].SetEmpty();
            }
        }
    }
}
