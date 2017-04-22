using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Image))]
public class TimerDisabled : MonoBehaviour {

    public float timeToRefill;
    public bool isActive = true;
    private UnityEngine.UI.Image _img = null; 


    // Use this for initialization
    void Start () {
        _img = GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Disable() {
        isActive = false;
        if (_img != null) {
                _img.color = new Color32(50, 50, 50, 100);
        }
        Invoke("Enable", timeToRefill);
    }

    public void Enable() {
        isActive = true;
        if (_img != null)
        {
            _img.color = new Color32(255, 255, 255, 100);
        }

    }
}
