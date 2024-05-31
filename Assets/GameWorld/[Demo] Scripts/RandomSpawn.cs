using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public List<GameObject> listObj;
    public float Radius = 1;
    int x;
    void Start(){
        for(x = 0; x<listObj.Count; x++){
            spawning();
        }
    }
    public void spawning(){
        Vector2 randomPos2D = Random.insideUnitCircle * Radius;
        Vector3 randomPos = new Vector3(randomPos2D.x, randomPos2D.y, 0) + transform.position;
        Instantiate(listObj[x], randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
