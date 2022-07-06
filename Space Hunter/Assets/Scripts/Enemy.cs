using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int maxHits = 4;

    ScoreBord scoreBord;

    // Start is called before the first frame update
    void Start()
    {  
        nonTriggerBoxCollider();  
        scoreBord = FindObjectOfType<ScoreBord>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void nonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        maxHits--;
        if(maxHits==0)
        {

            if (gameObject.tag == "Finish")
            {
                Invoke("LoadNextScene", 2f);
            }
            else
            {
                    scoreBord.ScoreHit(scorePerHit);
                    GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
                    fx.transform.parent = parent;
                    Destroy(gameObject);
               
            }
        }



    }


    private void LoadNextScene()
    {
        SceneManager.LoadScene(3);
    }

}
