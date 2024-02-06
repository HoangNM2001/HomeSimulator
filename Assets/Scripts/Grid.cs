using System.Collections.Generic;
using Pattern;
using UnityEngine;
using UnityEditor;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class Grid : MonoBehaviour
{
    [SerializeField] private PoolObject plate;
    
    private List<PoolObject> _plateList;
    private float _plateSize;

    private void Start()
    {
        _plateList = new List<PoolObject>();
        
        _plateSize = plate.GetComponentInChildren<MeshRenderer>().bounds.extents.x;
        // Debug.LogError(_plateSize);

        // GenerateGrid(2, 2);
    }

    public void GenerateGrid(int column, int row)
    {
        for (var i = 0; i < column; i++)
        {
            
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
    private Grid grid;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        grid = (Grid)target;
        
        EditorGUILayout.Space();

        if (GUILayout.Button("Generate Grid"))
        {
            grid.GenerateGrid(2, 2);
        }  
    }
}
#endif