using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class AttributeModifier : MonoBehaviour
{
    public GameObject playerObject;
    public void decreaseHeath(){
        Player player = playerObject.GetComponent<Player>();
        player.compiler.personInfo.heatlhPoints -= 1;
    }

    public void ModifyArtifactAttributes(int index, int newDurability, int newDamage)
    {
        Player player = playerObject.GetComponent<Player>();
        if (index >= 0 && index < player.compiler.ArtInfo.artifactNew.Count)
        {
            player.compiler.ArtInfo.artifactNew[index].durability = newDurability;
            player.compiler.ArtInfo.artifactNew[index].damage = newDamage;
        }
        else
        {
            Debug.LogWarning("Index out of range.");
        }
    }

    public void AddArtifact(string name, int id, int durability, int damage)
    {
        Player player = playerObject.GetComponent<Player>();
        Artifacts newArtifact = new Artifacts(name, id, durability, damage);
        Debug.Log("Added artifact: "+newArtifact.artifact_name);
        player.compiler.ArtInfo.artifactNew.Add(newArtifact); 
    }
}

//Modifies the player's attributes and adds artifacts into inventory