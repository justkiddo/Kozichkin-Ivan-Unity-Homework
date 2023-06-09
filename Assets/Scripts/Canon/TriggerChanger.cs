using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TriggerChanger : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI targetCountInfo;
    [SerializeField] private Button levelClearedButton;
    [SerializeField] private Button restartLevelButton;
    private List<GameObject> _targets;
    private int _targetsCount;


    private void Awake()
    {
        levelClearedButton.gameObject.SetActive(false);
        restartLevelButton.gameObject.SetActive(false);
        _targets = GameObject.FindGameObjectsWithTag("Targets").ToList();
        _targetsCount = _targets.Count;
    }

    private void Update()
    {
        targetCountInfo.text = _targetsCount.ToString();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Targets")) 
        {
            --_targetsCount;
            if (_targetsCount == 0)
            {
               levelClearedButton.gameObject.SetActive(true);
               restartLevelButton.gameObject.SetActive(true);
               targetCountInfo.gameObject.SetActive(false);
            }
        }
        
    }
}
