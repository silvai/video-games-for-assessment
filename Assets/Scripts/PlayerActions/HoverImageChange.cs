using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverImageChange : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button pb;
    public Sprite originalSprite;
    public Sprite newSprite;

    void Start()
    {
        pb = GetComponent<Button>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        pb.image.sprite = newSprite;
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
        pb.image.sprite = originalSprite;
        //Change Image back to default?
    }
}