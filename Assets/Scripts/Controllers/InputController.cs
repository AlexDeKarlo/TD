using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputController : MonoBehaviour
{
    [Inject] SceneUtility _sceneUtility;
    [Inject] IDataService _dataService;

    [SerializeField] private Camera _camera;
    [SerializeField,Min(0)] private float _speed;


    private float _multiplier = 1;
    private Vector2 _mapMaxSize;
    private PlayerInput _inputActions;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _inputActions = new PlayerInput();
        _inputActions.Enable();

        _mapMaxSize = _dataService.GetData().MapSize;
        _inputActions.Controlling.Esc.performed += (e) => _sceneUtility.LoadScene(0);
    }
    private void Update()
    {
        CameraMovement(_inputActions.Controlling.Move.ReadValue<Vector2>());

        _multiplier = Mathf.Clamp(_inputActions.Controlling.MoveMultiplier.ReadValue<float>() *2, 1, 2);

    }

    private Vector3 LimitationVector3(Vector3 value)
    {

        if (value.x > _mapMaxSize.x) value.x = _mapMaxSize.x;
        if (value.z > _mapMaxSize.y) value.z = _mapMaxSize.y;

        if (value.x<0) value.x = 0;
        if (value.z<0) value.z = 0;
        return new Vector3(value.x,_camera.transform.position.y,value.z);
    }

    private void CameraMovement(Vector2 vector2)
    {
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, LimitationVector3(_camera.transform.position + new Vector3(-vector2.y,0, vector2.x)), _speed * _multiplier * Time.deltaTime);
    }
}
