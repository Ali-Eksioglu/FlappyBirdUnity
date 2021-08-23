using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kusHareket : MonoBehaviour
{
    public bool isDead = false;
    public Rigidbody2D rb2D;
    public float velocity = 1f;
    public gameManager g_manager;

    public AudioSource UcmaSesi;

    public AudioSource Gameover;

    public AudioSource PuanSesi;

    private float egik = 0;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isDead == false && !g_manager.pause){
            UcmaSesi.Play();
            rb2D.velocity = Vector2.up * velocity ; 
        }
        if(rb2D.velocity.y > 2 && !g_manager.pause && isDead == false) {
            if(egik <= 20){
                egik += 5f;     
            }
            transform.rotation = Quaternion.Euler(0,0,egik);
        }
        else if(rb2D.velocity.y < 2 && egik > -80 && !g_manager.start && !g_manager.pause && isDead == false){
            egik-=0.5f;
            transform.rotation = Quaternion.Euler(0,0,egik);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "point"){
            g_manager.UpdateScore();
            PuanSesi.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Finish"){
            Debug.Log("değdin");
            isDead = true;
            Gameover.Play();
        }
    }
}
