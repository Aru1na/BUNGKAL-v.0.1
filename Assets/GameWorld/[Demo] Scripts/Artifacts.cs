

using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]

public class Artifacts
{
    public Artifacts(string artName, int artId, int dura, int dmg, CollectableType typeR, Sprite iconR, string descripR)
    {
        artifact_name = artName;
        art_id = artId;
        durability = dura;
        damage = dmg;
        type = typeR;
        icon = iconR;
        description = descripR;
    }

    public string description {get; set;}
    public Sprite icon {get; set;}
    public CollectableType type {get; set;}
    public string artifact_name { get; set; }
    public int art_id { get; set; }
    public int durability { get; set;}
    public int damage { get; set;}
}


//These are the object properties for the artifacts that will be given to the players.