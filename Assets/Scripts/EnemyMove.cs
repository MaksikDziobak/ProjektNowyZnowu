using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    public bool MoveRight;

    // Update is called once per frame
    void Update()
    {
        if(MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed , 0,0);
            transform.localScale = new Vector2 (1,1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed , 0,0);
            transform.localScale = new Vector2 (-1,1);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn"))
        {
            if(MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }

        if(trig.gameObject.CompareTag("Player"))
        {
            RestartLevel();
            Debug.Log("Player dies!");
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadSceneAsync("Level_2");
    }

}
