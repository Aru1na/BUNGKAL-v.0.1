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
        int x = 0;

        for (int i = 0; i<slots.Count; i++){
            while(x<player.compiler.artifactNew.Count){
                if (player.compiler.artifactNew[x].type != CollectableType.NONE){
                    slots[x].SetItem(player.compiler.artifactNew[x]);
                    Debug.Log("Hello");
                } 
                x++;
            }
            if (slots[i].empty == true){
                slots[i].gameObject.SetActive(false);
            }
        }

    }
}
