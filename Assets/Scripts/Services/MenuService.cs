using UnityEngine;
using Zenject;

public class MenuService : MonoBehaviour
{
    [Inject] private SceneUtility _sceneUtility;


    public void LoadLevel(int ID) => _sceneUtility.LoadScene(ID);
    public void LoadLevel(string name) => _sceneUtility.LoadScene(name);
}
