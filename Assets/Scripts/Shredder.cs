using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
        if (col.name == "EnemyInst")
        {
            Destroy(col.transform.parent.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
        }
	}
}
