using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour {

	public int health = 1;
    public GameObject ExplosionAnim;
	public float invulnPeriod = 0;
    
    float invulnTimer = 0;
	int correctLayer;
    
	SpriteRenderer spriteRend;

    GameObject scoreText;

    bool visible = renderer.isVisible;
        

    void Start() {

        scoreText = GameObject.FindGameObjectWithTag("ScoreCount");
        
		correctLayer = gameObject.layer;
        //Debug.LogError(correctLayer);

		// NOTE!  This only get the renderer on the parent object.
		// In other words, it doesn't work for children. I.E. "enemy01"
		spriteRend = GetComponent<SpriteRenderer>();

		if(spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if(spriteRend==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}

        
	}

    void OnTriggerEnter2D()
    {

        health--;

        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }

    }

    void Update() {

        

        if (invulnTimer > 0)
        {
            
            invulnTimer -= Time.deltaTime;          

            if (invulnTimer <= 0)
            {
               
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

		if(health <= 0)
        {
			Die();
        }

	}

	void Die()
    {
        PlayExplosion();

        if (gameObject.tag == "Enemy")
        {
            scoreText.GetComponent<GameScore>().Score += 100;
        }
        
		Destroy(gameObject);
	}

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionAnim);

        explosion.transform.position = transform.position;
    }
}
