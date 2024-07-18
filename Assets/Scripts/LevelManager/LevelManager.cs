using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    public List<Color> colorsRandom;

    [SerializeField] private int _index;

    private GameObject _currentLevel;

    private void Awake()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            //_index++;

            if(_index > levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[/*_index*/Random.Range(0, levels.Count - 1)], container);
        foreach (var c in GameObject.FindGameObjectsWithTag("Cylinder"))
        {
            if (c != null)
            {
                c.gameObject.GetComponent<MeshRenderer>().materials[0].SetColor("_Color", colorsRandom[Random.Range(0, colorsRandom.Count - 1)]);
            }
        }
        if(GameObject.FindGameObjectWithTag("Floor") != null)
        {
            GameObject.FindGameObjectWithTag("Floor").GetComponent<MeshRenderer>().materials[0].SetColor("_Color", colorsRandom[Random.Range(0, colorsRandom.Count - 1)]);
        }
        
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }
}
