using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    int gemSum=0;
    public Charater status;
    private void Awake() {
        status=GetComponent<Charater>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Gem")){
            Destroy(other.gameObject);
            gemSum++;
        }
    }
    private void OnGUI() {
        GUI.skin.label.fontSize=50;
        GUI.Label(new Rect(20,20,500,500),"      :"+gemSum);
        GUI.Label(new Rect(20,100,500,500),"Health:"+status.currentHealth);
    }
}
