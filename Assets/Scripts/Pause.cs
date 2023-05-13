using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenuPanel;
   

    private void Start()
    {
        //PauseMenuPanel = GameObject.FindWithTag("pauseMenu");
        
    }
    

    /*
    void OyunuDurdur()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelAcKapat = !PanelAcKapat;
        }
        

        if (PanelAcKapat)
        {
            Time.timeScale = 0;
            PauseMenuPanel.SetActive(PanelAcKapat);
        }
        else
        {
            Time.timeScale = 1;
            PauseMenuPanel.SetActive(PanelAcKapat);
        }
    }
    */

    public void OyunuDurdur()
    {
        Time.timeScale = 0;
        PauseMenuPanel.SetActive(true);
        

    }
    
    public void DevamEt()
    {
        Time.timeScale = 1;
        PauseMenuPanel.SetActive(false);

    }
















}
