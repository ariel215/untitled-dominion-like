using UnityEngine;
using UnityEngine.Events;

public class ButtonLike: MonoBehaviour
{
    public UnityEvent OnClick = new UnityEvent();


    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
    }
   
    
}
