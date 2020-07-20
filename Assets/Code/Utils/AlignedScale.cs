using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class AlignedScale : MonoBehaviour
{
    public enum Alignment { Top, Bottom, Left, Right };

    public Alignment alignment;

    float getFixedEdge()
    {
        var tfm = GetComponent<Renderer>();
        float ext;
        switch (alignment)
        {
            case Alignment.Top:
                ext = tfm.bounds.max.y;
                break;
            case Alignment.Bottom:
                ext = tfm.bounds.min.y;
                break;
            case Alignment.Left:
                ext = tfm.bounds.min.x;
                break;
            case Alignment.Right:
                ext = tfm.bounds.max.y;
                break;
            default:
                throw new System.Exception("Untreated Alignment option");
        }
        return ext;

    }

    private void Move(float dist)
    {
        var pos = transform.position;
        switch (alignment)
        {
            case Alignment.Bottom:
                pos.y += dist;
                break;
            case Alignment.Top:
                pos.y -= dist;
                break;
            case Alignment.Left:
                pos.x += dist;
                break;
            case Alignment.Right:
                pos.x -= dist;
                break;
            default:
                throw new System.Exception("Untreated Alignment option");
        }
        transform.position = pos;
    }

    public void Scale(Vector3 scale)
    {

        var old_edge = getFixedEdge();        
        transform.localScale = scale;
        var new_edge = getFixedEdge();

        Move(new_edge - old_edge);

    }
}
