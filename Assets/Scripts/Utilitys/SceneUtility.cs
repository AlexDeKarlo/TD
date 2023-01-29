using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour
{
    public void LoadScene(string name) => SceneManager.LoadScene(name);
    public void LoadScene(int id) => SceneManager.LoadScene(id);
}
