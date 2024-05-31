using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Collectable collect;
    public bool isRange;

    void Update()
    {
        if (isRange){
            if (Input.GetKeyDown(KeyCode.E))
            {
                collect.grabArtifact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        if (player){
            isRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        if (player){
            isRange = false;
            Debug.Log("Player out of range");
        }
    }
}
