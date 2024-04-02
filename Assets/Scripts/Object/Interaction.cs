using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private TMP_Text InteractionText;
    [SerializeField] private TMP_Text NotificationText;
    private bool isInteractable = false;
    public int type;
    
    // Start is called before the first frame update
    void Start()
    {
        InteractionText.gameObject.SetActive(false);
        NotificationText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInteractable)
        {
            // 상호작용 키
            if (Input.GetKeyDown(KeyCode.E)) { 
                switch(type)
                {
                    case 1:
                        Notify("가만히 있으면 돌하르방이 찾지 못합니다.");
                        break;
                    case 2:
                        Notify("늪에 가만히 있으면 가라앉습니다.");
                        break;
                    case 3:
                        Notify("집을 찾기 위해선 돌하르방을 유심히 보세요.");
                        break;
                    case 4:
                        Notify("소리를 낸다면... 돌하르방이 올 것입니다.");
                        break;
                    default:
                        break;
                }
                InteractionText.gameObject.SetActive(false); 
                Destroy(this.gameObject);
            }
        }
    }

    void Notify(string s)
    {
        NotificationText.gameObject.SetActive(true);
        NotificationText.text = s;
        FindObjectOfType<GameManager>().StartCoroutine(NotificationDisappear());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Turns on the interaction prompt.
            InteractionText.gameObject.SetActive(true);

            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = false;
            InteractionText.gameObject.SetActive(false);
        }
    }

    IEnumerator NotificationDisappear()
    {
        yield return new WaitForSeconds(2.0f);
        
        NotificationText.gameObject.SetActive(false);
    }
}
