using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroInterface : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        SceneManager.LoadScene("How to Play"); // Jumps to another scene

        // Anything put below this line of code WON'T BE EXECUTED
    }

    public void Difficulty()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log ("Quit!");
    }

    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }
}
