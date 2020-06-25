using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 3)
        {
            resetScene();
        }
    }

    public void resetScene()
    {
        SelectionManager selectionManager = FindObjectOfType<SelectionManager>();
        selectionManager.ExitDetailPage();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
