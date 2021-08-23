using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public int score;
    public Text ScoreText;

    public int level = 0;
    public kusHareket kusDurum;

    public boruHareket boruhereket;

    public GameObject StartScrean;

    public GameObject DeathScrean;

    public GameObject PauseScrean;
    public Text DeadScore;

    public Text PauseScore;

    public boruspawner spawn; 

    public bool start = true;

    public bool pause = false;

    void Start()
    {
        score = 0;
        DeathScrean.SetActive(false);
        PauseScrean.SetActive(false);
        StartScrean.SetActive(start);
        ScoreText.text = score.ToString();
        Time.timeScale = 0;
    }

    private void Update() {
        if(start){
            if(Input.GetMouseButtonDown(0)){
                start = false;
                kusDurum.isDead = false;
                Time.timeScale = 1;
                StartScrean.SetActive(false);
                StartCoroutine(spawn.SpawnBoru());
            }
        }
        if(kusDurum.isDead == true){
            Time.timeScale = 0;
            DeathScrean.SetActive(true);
            DeadScore.text = score.ToString();
        }
        if(Input.GetKeyUp(KeyCode.Escape) && !kusDurum.isDead && !start){
           PauseGame();
        }
    }        

   public void UpdateScore(){
       score++;
       ScoreText.text = score.ToString();
       if(score > level){
            level = Random.Range(score+2,score+10); 
            spawn.spawntime-=0.5f;
            boruhereket.speed+=0.3f;
            Debug.Log("time= " + spawn.spawntime);
            Debug.Log("speed = " + boruhereket.speed);
            Debug.Log("leve = " + level);

       }
   }

   public void RestartGame(){
       SceneManager.LoadScene(0);
   }
   public void PauseGame(){
        if(pause==false){
            Time.timeScale = 0;
            PauseScore.text = score.ToString();
            PauseScrean.SetActive(true);
            pause=true;
        }
        else if(pause==true){
            PauseScrean.SetActive(false);
            pause=false;
            Time.timeScale = 1;
        }    
   }
}
