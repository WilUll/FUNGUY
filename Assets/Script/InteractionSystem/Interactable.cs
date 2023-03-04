using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Interactable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Material materialOnObject;
    [SerializeField] private GameObject particleSystem;
    [SerializeField] Item item;
    
    // Start is called before the first frame update
    void Start()
    {
        materialOnObject = GetComponentInChildren<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse is over GameObject.");
        materialOnObject.SetInt("_HighLight", 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse is no longer on GameObject.");
        materialOnObject.SetInt("_HighLight", 0);

    }

    public void PickUp()
    {
        bool success = InventoryManager.Instance.AddItem(item);
        if (success)
        {
            var ps = Instantiate(particleSystem, transform.position, Quaternion.identity);
            ps.GetComponent<ParticleSystem>().Play();
            Destroy(ps, 5);
            Destroy(this.gameObject);
        }

    }
}
