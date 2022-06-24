using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
    public static GameControl instance;            //A reference to our game control script so we can access it statically.
    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -1.5f;
    public float scrollSpeed2 = -2f;

    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.
    public GameObject highlight;
    public GameObject playAgainButton;
    public GameObject mainMenuButton;
    private AudioSource click;
    public AudioSource Death;


    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
    }

    void Start()
    {
        click = GetComponent<AudioSource>();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene ("Intro");
    }

    public void Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload
        // Anything put below this line of code WON'T BE EXECUTED
    }

    public void BirdDied()
    {
        // Activate the game over UI
        Timer.instance.EndTimer();
        Death.Play();
        gameOvertext.SetActive (true);
        playAgainButton.SetActive (true);
        mainMenuButton.SetActive (true);
        highlight.SetActive (true);

        //Set the game to be over.
        gameOver = true;
    }
}
