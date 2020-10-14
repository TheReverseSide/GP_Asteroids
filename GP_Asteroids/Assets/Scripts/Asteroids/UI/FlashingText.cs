using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlashingText : MonoBehaviour
{

    Text flashingText;
 
    void Start(){
        flashingText = this.GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    //function to blink the text
    public IEnumerator BlinkText(){
        //Currently blinks forever
        while(true){
            //set the Text's text to blank
            
            flashingText.text= "PRESS 'SPACE' TO START";
            yield return new WaitForSeconds(.7f);
            
            flashingText.text= "";
            yield return new WaitForSeconds(.7f);
        }
    }
}
