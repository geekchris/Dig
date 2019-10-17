using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject PauseMenuUI;
    public void Quit()
    {
        Debug.Log("APPLICATION QUIT.");
        Application.Quit();
    }

    /**public void Pause()
    *{
    *    if(isPaused)
    *    {
    *        Debug.Log("UNPAUSED");
    *        Unpause();
    *    }
    *    else
    *    {
    *        Debug.Log("PAUSED");
    *        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    *        Time.timeScale = 0.0f;
    *    }
    *}
    */
    public void Unpause()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("UNPAUSED");
        //StartCoroutine("PauseWait");
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        Debug.Log("PAUSED");
        //StartCoroutine("PauseWait");
    }

    IEnumerator PauseWait()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
