using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{        
    public CollectableType type;
    public Sprite icon;
    public string Description;
    public void grabArtifact(){
        Player player = FindObjectOfType<Player>();
        Artifacts art = new Artifacts(type.ToString(), 1, 100, 100, type, icon, Description);
        player.AddArtifact(art);
        Destroy(this.gameObject);
    }
    //When a player comes across this object, it will do the action that is specified above
}
public enum CollectableType{
    NONE, STONE, CHICKEN
}
