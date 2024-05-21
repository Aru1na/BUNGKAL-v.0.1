using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{        
    [SerializeField] public GameObject attributesModify;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Artifacts newArtifact = new Artifacts("Something", 1, 100, 100);
        AttributeModifier modify = attributesModify.GetComponent<AttributeModifier>();
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            modify.AddArtifact("Hello", 1, 100, 100);
            Destroy(this.gameObject);
        }
    }
    //When a player comes across this object, it will do the action that is specified above
}
