using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class SetSortingLayer : MonoBehaviour
{

    [SerializeField]
    private string LayerName;

    [SerializeField]
    private int LayerNumber;

    void apply()
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = LayerName;
        renderer.sortingOrder = LayerNumber;
    }

    private void OnEnable()
    {
        apply();
    }

    private void OnValidate()
    {
        apply();
    }

}
