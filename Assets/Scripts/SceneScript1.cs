using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("Stage 2");
        }

        //go back to previous scene
        if(Input.GetKey(KeyCode.LeftArrow)){
            SceneManager.LoadScene("Title Screen");
        }

        //restart scene
        if(Input.GetKey(KeyCode.UpArrow)){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
