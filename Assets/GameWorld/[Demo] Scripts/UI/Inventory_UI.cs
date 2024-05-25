using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour, IPointerClickHandler
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
        while(x<player.compiler.artifactNew.Count){
            if (player.compiler.artifactNew[x].type != CollectableType.NONE){
                slots[x].SetItem(player.compiler.artifactNew[x]);
                slots[x].OnItemClicked += HandleItemSelect;
                slots[x].OnRightMouseBtnClick += HandleShowItemActions;
                Debug.Log("Hello");
            } 
            x++;
        }
        for (int i = x; i<slots.Count; i++){
            if (slots[i].empty == true){
                slots[i].Hide();
            }
        }
    }

    private void HandleShowItemActions(Slots_UI uI)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelect(Slots_UI uI)
    {
        Debug.Log(uI.artNew.artifact_name);

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
