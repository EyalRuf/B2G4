﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private string selectableTag = "selection";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Transform _selection;

    // Update is called once per frame
    void Update()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
            }

        }
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    var selection = hit.transform;
        //    if (_selection == null)
        //    {
        //        SaveSelectable(hit.transform);
        //    }
        //    else if (_selection.GetInstanceID() != selection.GetInstanceID())
        //    {
        //        var selectionRenderer = _selection.GetComponent<Renderer>();
        //        selectionRenderer.material = defaultMaterial;
        //        SaveSelectable(selection);
        //    }
        //}
        //else if (_selection != null)
        //{
        //    var selectionRenderer = _selection.GetComponent<Renderer>();
        //    selectionRenderer.material = defaultMaterial;
        //    _selection = null;
        //}
    }
}
    //void SaveSelectable(Transform selection)
    //{
    //    if (selection.CompareTag(selectableTag))
    //    {
    //        var selectionRenderer = selection.GetComponent<Renderer>();
    //        if (selectionRenderer != null)
    //        {
    //            selectionRenderer.material = highlightMaterial;
    //        }

    //        _selection = selection;
    //    }
    //}
