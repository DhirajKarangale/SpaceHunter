using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] float xRange = 20f;
    [SerializeField] float yRange = 8f;
    [SerializeField] float posPitchFactor = 0.3f;
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float posYawFactor = 0.1f;
    [SerializeField] float controlYawFactor = -10f;
    [SerializeField] float controlRollFactor = -15f;
    [SerializeField] GameObject[] guns; 

    bool isControlEnabled = true;

   private float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(isControlEnabled)
       {
            movement();
            Firing();
       }

       if(!isControlEnabled)
        {
            DeActivateGuns();
        }
    }



    

    void PlayerDyes()
    {
        isControlEnabled = false;
    }


    private void movement()
    {

        rotation();
        transasition();
    }

    private void rotation()
    {
        float pitch = transform.localPosition.y * posPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * posYawFactor + xThrow * controlYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
        

    private void transasition()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xMove = xThrow * speed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xMove;
        float xPosRange = Mathf.Clamp(newXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yMove = yThrow * speed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yMove;
        float yPosRange = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xPosRange, yPosRange, transform.localPosition.z);
    }

    private void Firing()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }
     


   private void SetGunsActive(bool isActive)
    {
        foreach(GameObject gun in guns)
        {
            var emissionModule  = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

   

    private void DeActivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

}



