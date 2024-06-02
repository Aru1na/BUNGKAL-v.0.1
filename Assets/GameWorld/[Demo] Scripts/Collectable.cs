using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{        
    public int artID;
    public CollectableType type;
    public Sprite icon;
    public string artifactName;
    public string Description;
    public int points = 0;
    public void QuestionBox()
    {

    }
    public void grabArtifact(){
        if (type == CollectableType.QUESTION){
            Debug.Log("Question Type");
            Destroy(this.gameObject);
        }else if (type == CollectableType.NONE) {
            Debug.Log("No item");
            Destroy(this.gameObject);
        } else {
            Player player = FindObjectOfType<Player>();
            Artifacts art = new Artifacts(artID, artifactName, type, icon, Description, points);
            player.AddArtifact(art);
            Destroy(this.gameObject);
        }
    }
    //When a player comes across this object, it will do the action that is specified above
}
public enum CollectableType{
    NONE, QUESTION, SUNGKA, BALISONG, MAQUINA_DE_MANO, CANDELABRUM
}
