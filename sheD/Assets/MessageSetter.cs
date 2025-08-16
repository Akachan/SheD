using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSetter : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI text;
   [SerializeField] private float characterDelay = 0.1f;
   [SerializeField] private float hideDelay = 2f;

   private void Awake()
   {
       text.text = "";
       
   }
   public void SetMessage(string message)
   {
       
       StopAllCoroutines();
       StartCoroutine(AnimateText(message));
   }

   private IEnumerator AnimateText(string message)
   {
       text.text = "";
       foreach (char c in message)
       {
           text.text += c;
           yield return new WaitForSeconds(characterDelay);
       }

       yield return new WaitForSeconds(hideDelay);
       
       text.text = "";
   }
}
