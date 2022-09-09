using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ApplicationManager : ScriptableObject
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
    
    public void LoadNeaLevel1()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    
    public void LoadNeaLevel2()
    {
        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }
    
    public void LoadNeaLevel3()
    {
        SceneManager.LoadScene(3,LoadSceneMode.Single);
    }
    
    public void LoadReiLevel1()
    {
        SceneManager.LoadScene(4,LoadSceneMode.Single);
    }
    
    public void LoadReiLevel2()
    {
        SceneManager.LoadScene(5,LoadSceneMode.Single);
    }
    
    public void LoadReiLevel3()
    {
        SceneManager.LoadScene(6,LoadSceneMode.Single);
    }
    
    public void LoadLanLevel1()
    {
        SceneManager.LoadScene(7,LoadSceneMode.Single);
    }
    
    public void LoadLanLevel2()
    {
        SceneManager.LoadScene(8,LoadSceneMode.Single);
    }
    
    public void LoadLanLevel3()
    {
        SceneManager.LoadScene(9,LoadSceneMode.Single);
    }
}
