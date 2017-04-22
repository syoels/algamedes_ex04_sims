using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    private Vector2 _initialPosition;
    public GameObject createOnDrop = null;
    public Transform dropParent = null;
    private Rect _invalidArea = new Rect(0f, 0f, 0f, 0f);
    private TimerDisabled _disabler = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData) {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.position = _initialPosition;
        if (_invalidArea.Contains(eventData.position))
        {
            return;
        }
        if (_disabler != null && !_disabler.isActive) {
            return;
        }
        if (createOnDrop != null)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(eventData.position);
            GameObject prefab = Instantiate(createOnDrop, position, transform.rotation);
            if (dropParent != null) {
                prefab.transform.parent = dropParent;
            }
            if (_disabler != null)
            {
                _disabler.Disable();
            }
        }
        else {
            Debug.Log("Nothing to create! fix in inspector");
        }
    }

    // Use this for initialization
    void Start () {
        _initialPosition = this.transform.position;
        _disabler = GetComponent<TimerDisabled>();
        RectTransform rect = GetComponentInParent<RectTransform>();
        _invalidArea = new Rect(rect.rect); //TODO: this doesnt create the desired rec (should be same as panel)
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
