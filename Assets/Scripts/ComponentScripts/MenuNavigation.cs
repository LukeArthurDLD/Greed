using UnityEngine;
using UnityEngine.SceneManagement;

/*  MENU NAVIGATION COMPONENT SCRIPT
 *  
 *  VERSION: 2021.11.02 AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *  Script is used for navigating menus in game
 *  Script is modular for various UI & menu functionality options
 *  
 *  DIRECTIONS FOR USE:
 *  
 *  1. Attach to any game object
 *  2. Wire attached game object to any UI element for functionality
 *  
 */

public class MenuNavigation : MonoBehaviour
{   
    private int _currentBuildIndex = 0;
    private int _nextBuildIndex;
    private int _prevBuildIndex;

    private void CalculateBuildIndex()
    {
        _currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        _prevBuildIndex = _currentBuildIndex - 1;
        _nextBuildIndex = _currentBuildIndex + 1;

        if (_prevBuildIndex < 0)
        {
            _prevBuildIndex = 0;
        }
    }

    public void RefreshScene()
    {
        CalculateBuildIndex();
        SceneManager.LoadScene(_currentBuildIndex);
    }

    public void LoadNextScene()
    {
        CalculateBuildIndex();
        SceneManager.LoadScene(_nextBuildIndex);
    }

    public void LoadPrevScene()
    {
        CalculateBuildIndex();
        SceneManager.LoadScene(_prevBuildIndex);
    }

    public void LoadAnyScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
