using UnityEngine;

public class OnMouseScale : MonoBehaviour
{
    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.1f, 1.1f);
    }


    public void PointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
