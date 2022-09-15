using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//todo: colocar a instancia do indicador para o IndicatorScript e separar os scripts com as suas devidas funcionalidades
//todo: relacionar a posicao da INSTANCIA do prefab do indicador com a area que ele esta em cima, e assim, quando apertar espaco, mudar o seu estado
public class BoardManager : MonoBehaviour
{

    public int _colums = 6;
    public int _rows = 6;
    public int _numberOfFlorest = 15;
    public int _numberofVillages = 13;
    public int _numberOfRivers = 5;
    public int _numberOfCities = 3;
    public int areaType;
    public GameObject _florest;
    public GameObject _village;
    public GameObject _river;
    public GameObject _city;
    public GameObject _indicator;
    public IndicatorScript indicatorScript;
    public Vector3 _indicatorPosition = new Vector3(0, 0, -1);
    public List<Vector3> gridPosition = new List<Vector3>();
    public List<Vector3> florestPositions = new List<Vector3>();
    public List<Vector3> villagePositions = new List<Vector3>();
    public List<Vector3> riverPositions = new List<Vector3>();
    public List<Vector3> cityPositions = new List<Vector3>();
    public List<List<Vector3>> positions = new List<List<Vector3>>();
    public event Action OnAreaFound;
    public GameObject indicatorInstance;
    void InitializeGrid()
    {
        gridPosition.Clear();

        for (int x = -3; x < _colums - 3; x++){

            for (int y = -2; y < _rows -2; y++){
                gridPosition.Add(new Vector3(x, y, 0f));
            }
        }
    }

    Vector3 RandomPoint()
    {
        int randomIndex = Random.Range(0, gridPosition.Count);

        Vector3 randomPoint = gridPosition[randomIndex];
       
        gridPosition.RemoveAt(randomIndex);
       
        return randomPoint;
    }

    void LayoutAtRandom(GameObject type, int occurrences, List<Vector3> positionsList){

        for (int i = 0; i < occurrences; i++){

            Vector3 randomPoint = RandomPoint();
            
            positionsList.Add(randomPoint);
            
            Instantiate(type, randomPoint, Quaternion.identity);

        }

    }
    void GetAreaTypeByPosition(Vector3 position)
    {
        Vector3 correctedPosition = new Vector3(position.x, position.y, 0f);
        foreach(List<Vector3> rows in positions)
        {
            foreach(Vector3 points in rows)
            {
                if (correctedPosition == points)
                {
                    areaType = positions.IndexOf(rows);
                    OnAreaFound?.Invoke();
                }

            }
        }
    }

    private void Awake()
    {
        indicatorInstance = Instantiate(_indicator, _indicatorPosition, Quaternion.identity);
        indicatorScript = indicatorInstance.GetComponent<IndicatorScript>();
    }

    void OnEnable() 
    {
        indicatorScript.SpacePressed += GetAreaTypeByPosition;
    }

    void OnDisable() 
    {
        indicatorScript.SpacePressed -= GetAreaTypeByPosition;
    }
    void Start()
    {
        InitializeGrid();
        LayoutAtRandom(_florest, _numberOfFlorest, florestPositions);
        LayoutAtRandom(_village, _numberofVillages, villagePositions);
        LayoutAtRandom(_river,_numberOfRivers, riverPositions);
        LayoutAtRandom(_city,_numberOfCities, cityPositions);
        positions.Add(florestPositions);
        positions.Add(villagePositions);
        positions.Add(riverPositions);
        positions.Add(cityPositions);
    }

}
