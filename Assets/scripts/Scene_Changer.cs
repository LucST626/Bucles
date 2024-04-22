using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    [SerializeField] string nameScene;
    void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene(nameScene);
    }
}
