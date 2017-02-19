using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    
    public GameObject health1of4;
    public GameObject health2of4;
    public GameObject health3of4;
    public GameObject health4of4;

    GameObject playerInstance;

    float respawnTimer;

    public int numLives = 4;

    public GameObject playButton;
    public GameObject exitButton;
    public GameObject gameOver;

    public GameObject scoreText;

    private bool invincible = false;

    // Use this for initialization

    void Start () {

        gameOver.SetActive(false);
    }

    public void StartGame()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        gameOver.SetActive(false);
        numLives = 4;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);

        scoreText.GetComponent<GameScore>().Score = 0;

          SpawnPlayer();
    }

    void SpawnPlayer()
    {
        
        numLives--;
        
        respawnTimer = 2;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);

        gameObject.layer = 10;
        invincible = true;

        Invoke("resetInvulnerability", 2);

    }

    void resetInvulnerability()
    {
        gameObject.layer = 8;
        invincible = false;
    }

    // Update is called once per frame
    void Update ()
    {



	    if (playerInstance == null && numLives > 0)
        {
            
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0 && playButton.activeSelf == false)
            {
                SpawnPlayer();              
            }
            
        }
	}

    void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
            if (numLives == 3)
            {
                health1of4.SetActive(true);
                health2of4.SetActive(true);
                health3of4.SetActive(true);
                health4of4.SetActive(true);

                }
            if (numLives == 2)
            {
                health1of4.SetActive(true);
                health2of4.SetActive(true);
                health3of4.SetActive(true);
                health4of4.SetActive(false);}
            if (numLives == 1)
            {
                health1of4.SetActive(true);
                health2of4.SetActive(true);
                health3of4.SetActive(false);
                health4of4.SetActive(false);}
            if (numLives == 0)
            {
                health1of4.SetActive(true);
                health2of4.SetActive(false);
                health3of4.SetActive(false);
                health4of4.SetActive(false);}
            //GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
        }
        else
        {
            health1of4.SetActive(false);
            health2of4.SetActive(false);
            health3of4.SetActive(false);
            health4of4.SetActive(false);


            gameOver.SetActive(true);
            playButton.SetActive(true);
            exitButton.SetActive(true);

            //GUI.Label(new Rect(Screen.width/2 -50, Screen.height/2-25, 100, 50), "Game Over, Man!");

            //GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.GameOver);
        }

    }
}
