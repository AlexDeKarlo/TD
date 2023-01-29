using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUIContent : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _name;
    [SerializeField] TMPro.TMP_Text _description;
    [SerializeField] Button _buy;

    public TMPro.TMP_Text Name => _name;
    public TMPro.TMP_Text Description => _description;
    public Button Buy => _buy;
}
