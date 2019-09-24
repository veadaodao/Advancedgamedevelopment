using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PiggyController : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;
    Transform cannon;

    public ScoreManager scoreManager;
    bool resetting = false;
    public GameObject boom;
    public AudioSource boomsound;

    public Text HighScore;
    public TextMeshProUGUI Score;
    private int number;

    void Start()
    {

        HighScore.text = "High Score:"+PlayerPrefs.GetInt("HighScore",0).ToString();

        cannon = transform.parent;
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
        
    }


    void Update()
    {
        number = scoreManager.score;
        if(number> PlayerPrefs.GetInt("HighScore",0))
        {

            PlayerPrefs.SetInt("HighScore", number);
        }
    }

    private void OnCollisionEnter2D(Collision2D colinfo)
    {
        if (colinfo.gameObject.tag == "box")
        {
            scoreManager.updateScore(1);
            GameObject explosion = Instantiate(boom, transform.position, Quaternion.identity);
            boomsound.Play();
            Destroy(explosion, 0.5f);
        }
        if (colinfo.gameObject.tag == "bird")
        {
            scoreManager.updateScore(100);
        }
        if (colinfo.relativeVelocity.magnitude<0f)
        {
            if (resetting == false)
            {

                Invoke("ResetPiggy", 4f);
                resetting = true;
            }
        }
        if (colinfo.gameObject.tag == "outside"||colinfo.gameObject.tag == "trap")
        {
            if (resetting == false)
            {

                Invoke("ResetPiggy", 2f);
                resetting = true;
            }
        }
    }

    public void ResetPiggy()
    {

        transform.parent = cannon;
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        resetting = false;
    }   
    public void ResetHighScore()
    {
        HighScore.text = "High Score:" + 0;
        PlayerPrefs.DeleteAll();
    }
}