using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusButton : MonoBehaviour
{
    public Score score_obj;
    private Button bonus_button;
    // Start is called before the first frame update

   void Start()
    {
        
        bonus_button = GetComponent<Button>();
        bonus_button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        score_obj.SetBonus(2, 3f);
    }
}
