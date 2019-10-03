using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Mask))]
[RequireComponent(typeof(ScrollRect))]
public class ScrollSnapRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private ScrollRect _scrollRectComponent;
    private RectTransform _scrollRectRect;
    private RectTransform _container;
    
    // number of pages in container
    private int _pageCount;

    // target position of every page
    private List<Vector2> _pagePositions = new List<Vector2>();

    //------------------------------------------------------------------------
    void Start()
    {
        _scrollRectComponent = GetComponent<ScrollRect>();
        _scrollRectRect = GetComponent<RectTransform>();
        _container = _scrollRectComponent.content;
        _pageCount = _container.childCount;

        // is it horizontal or vertical scrollrect
        if (!_scrollRectComponent.horizontal || _scrollRectComponent.vertical)
        {
            Debug.LogWarning("Il faut set le scroll view en horizontal seulement");
        }

        // init
        SetPagePositions();
    }

    //------------------------------------------------------------------------
    void Update()
    {}

    //------------------------------------------------------------------------
    private void SetPagePositions()
    {
        Debug.Log($"SetPagePositions");

        int width = 0;
        int containerWidth = 0;
        int containerHeight = 0;


        // screen width in pixels of scrollrect window
        width = (int)_scrollRectRect.rect.width;

        // total width
        containerWidth = width * (_pageCount -1);

        Debug.Log($"containerWidth :{containerWidth}");
        // set width of container
        Vector2 newSize = new Vector2(containerWidth, containerHeight);
        _container.sizeDelta = newSize;
        Vector2 newPosition = new Vector2(containerWidth / 2, containerHeight / 2);
        _container.anchoredPosition = newPosition;

        // delete any previous settings
        _pagePositions.Clear();

        // iterate through all container children and set their positions
        for (int i = 0; i < _pageCount; i++)
        {
            RectTransform child = _container.GetChild(i).GetComponent<RectTransform>();
            Vector2 childPosition;
            childPosition = new Vector2(i * width - containerWidth / 2, 0f);
            child.anchoredPosition = childPosition;
            _pagePositions.Add(-childPosition);
        }
    }

    //------------------------------------------------------------------------
    public void OnBeginDrag(PointerEventData aEventData)
    {}

    //------------------------------------------------------------------------
    public void OnEndDrag(PointerEventData aEventData)
    {}

    //------------------------------------------------------------------------
    public void OnDrag(PointerEventData aEventData)
    {}
}
