﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts
{
    public class MouseLook: MonoBehaviour
    {

        [SerializeField] private string selectableTag = "selection";
        [SerializeField] private Material highlightMaterial;
        [SerializeField] private Material defaultMaterial;
        public float mouseSensitivity = 100f;
        public Transform playerBody;
        float xRotation = 0f;
        private Transform _selection;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (_selection.GetInstanceID() != hit.rigidbody.transform.GetInstanceID())
                {
                    var selectionRenderer = _selection.GetComponent<Renderer>();
                    selectionRenderer.material = defaultMaterial;
                    _selection = null;
                    SaveSelectable(selection);
                }

            }
            void SaveSelectable(Transform selection)
            {
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
        }
    }

}

