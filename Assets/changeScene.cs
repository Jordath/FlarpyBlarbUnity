using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [ContextMenu("Increase Score")]
    public void changeScenebyID(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
