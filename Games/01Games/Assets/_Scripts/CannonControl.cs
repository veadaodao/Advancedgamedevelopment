using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CannonControl : MonoBehaviour
{
    public Rigidbody2D piggyRB; 
    public Camera mainCamera;
    Vector3 direction;

    const float STRENTH = 200; 
    const int MAX_ANGLE = 80;
    const int MIN_ANGLE = 5;

    bool piggyshot = false;

    public AudioSource shotsound;
    public AudioSource MainSound;
    public LevelManager levelManager;

    int DieLife;
    public GameObject Restart;
    void Start()
    {
        piggyRB.AddForce(direction* STRENTH *piggyRB.mass*0);
        piggyRB.gravityScale = 0;
        MainSound.Play();
    }


    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -mainCamera.transform.position.z);

        Vector3 mousePositionInWorldCoordinates = mainCamera.ScreenToWorldPoint(mousePosition);
        direction = mousePositionInWorldCoordinates - transform.position;

        float alpha = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;

        if (alpha < MAX_ANGLE && alpha > MIN_ANGLE && direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, alpha));
        }

        DieLife = levelManager.level;
        if (DieLife > 3)
        {
            Restart.gameObject.SetActive(true);
            piggyshot = true;
            Instantiate(Restart, transform.position, Quaternion.identity);
            Debug.Log("Lose");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonUp("Fire1")&&piggyshot==false)
        {
            piggyRB.transform.parent = null;
            piggyRB.gravityScale = 1;
            piggyRB.AddForce(direction * STRENTH * piggyRB.mass);
            piggyshot = true;
            shotsound.Play();
            Debug.Log("fire");
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetPiggy();
        }
        
    }

    public void ResetPiggy()
    {
        piggyshot = false;
        levelManager.updateLevel(1);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
