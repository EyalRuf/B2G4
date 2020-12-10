using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PickUpController : MonoBehaviour
    {
        //public ToolUsage WrenchScript;
        public Rigidbody rb;
        public SphereCollider coll;
        public Transform player, HoldingPlace, MainCamera;

        public float pickUpRange;
        public float dropForwardForce, dropUpwardForce;

        public bool equipped;
        public static bool slotFull;

        private void Start()
        {
            //Setup
            if (!equipped)
            {
            //WrenchScript.enabled = false;
                rb.isKinematic = false;
                coll.isTrigger = false;
            }
            if (equipped)
            {
            //WrenchScript.enabled = false;
                rb.isKinematic = true;
                coll.isTrigger = true;
                slotFull = true;
            }
        }

        private void Update()
        {
            //Check if player is in range and "E" is pressed
            Vector3 distanceToPlayer = player.position - transform.position;
            if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

            //Drop if equipped and "Q" is pressed
            if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
        }

        private void PickUp()
        {
            equipped = true;
            slotFull = true;

            transform.SetParent(HoldingPlace);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

            //Makes Rigidbody kinematic and BoxCollider a trigger
            rb.isKinematic = true;
            coll.isTrigger = true;
        }

        private void Drop()
        {
            equipped = false;
            slotFull = false;

            //Set parent to null
            transform.SetParent(null);

            //Make Rigidbody not kinematic and BoxCollider normal
            rb.isKinematic = false;
            coll.isTrigger = false;


            //AddForce 
            rb.AddForce(MainCamera.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(MainCamera.up * dropUpwardForce, ForceMode.Impulse);
            //Add random rotation to the tool when dropped
            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 10);


        }
    }
    //public Transform Hold;

    //void OnMouseDown()
    //{
    //    GetComponent<Rigidbody>().useGravity = false;
    //    this.transform.position = Hold.position;
    //    this.transform.parent = GameObject.Find("HoldingPlace").transform;
    //}

    //void OnMouseUp()
    //{
    //    this.transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //    GetComponent<Collider>().enabled = true;
    //}


    //[SerializeField] private string selectableTag = "selection";
    //[SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material defaultMaterial;
    //private Transform _selection;

    //void Update()
    //{

    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        var selection = hit.transform;
    //        if (_selection.GetInstanceID() != hit.rigidbody.transform.GetInstanceID())
    //        {
    //            var selectionRenderer = _selection.GetComponent<Renderer>();
    //            selectionRenderer.material = defaultMaterial;
    //            _selection = null;
    //            SaveSelectable(selection);
    //        }

    //    }
    //    void SaveSelectable(Transform selection)
    //    {
    //        if (selection.CompareTag(selectableTag))
    //        {
    //            var selectionRenderer = selection.GetComponent<Renderer>();
    //            if (selectionRenderer != null)
    //            {
    //                selectionRenderer.material = highlightMaterial;
    //            }

    //            _selection = selection;
    //        }
    //    }
    //}

    //int hit:RaycastHit;
    // int pickedUpObject:GameObject;

    //private void Update()
    //{
    //    if (Input.GetKey("e")) {

    //        if (Physics.Raycast(transform.position, transform.forward, hit, 100)) {

    //            if (hit.collider.gameObject.tag == "selection") { //add collider reference otherwise you can't access gameObject!

    //                pickedUpObject = hit.collider.gameObject;
    //                hit.collider.gameObject.transform.parent = transform;
    //                hit.collider.gameObject.transform.position = transform.position - transform.forward;
    //            }
    //        }
    //    } else
    //    { //i think a regular else statement is fine

    //        pickedUpObject.transform.parent = null;
    //        pickedUpObject = null;

    //    }
    //}

    //var hit:RaycastHit;
    // v GameObject pickedUpObject;


    //void Update()
    //{


    //    if (Input.GetKey("e"))
    //    {

    //        if (Physics.Raycast(transform.position, transform.forward, hit, 100f))
    //        {

    //            if (hit.collider.gameObject.tag == "cube")
    //            { //add collider reference otherwise you can't access gameObject!

    //                pickedUpObject = hit.collider.gameObject;
    //                hit.collider.gameObject.transform.parent = transform;
    //                hit.collider.gameObject.transform.position = transform.position - transform.forward;
    //            }
    //        }
    //    }
    //    else
    //    { //i think a regular else statement is fine

    //        pickedUpObject.transform.parent = null;
    //        pickedUpObject = null;

    //    }
    //}
