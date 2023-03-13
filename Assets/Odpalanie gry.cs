using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Odpalaniegry : MonoBehaviour
{
    // Start is called before the first frame update
  public void LoadNextScene()
    {
       // SceneManager.LoadScene("level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
