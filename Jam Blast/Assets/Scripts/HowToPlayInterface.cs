using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayInterface : MonoBehaviour
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
        SceneManager.LoadScene("Intro"); // Jumps to another scene

        // Anything put below this line of code WON'T BE EXECUTED
    }
}
