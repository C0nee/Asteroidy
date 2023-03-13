using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void newGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Mainmenu(){
        SceneManager.LoadScene("Main_Menu");
   }
}
