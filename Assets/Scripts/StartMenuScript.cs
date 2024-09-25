using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    
    public GameObject Menu1;
    public GameObject Menu2;

    public void QuitGame(){
        Application.Quit();
    }

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void InfoMenu(){
        Menu1.SetActive(false);
        Menu2.SetActive(true);
    }

    public void HomeMenu(){
        Menu1.SetActive(true);
        Menu2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Menu1.SetActive(true);
        Menu2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
