using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

namespace MainGame
{
    [DisallowMultipleComponent]
    public abstract class popupBase : MonoBehaviour
    {
        [SerializeField] protected GameObject container;
        [SerializeField] protected TMP_Text txtTitle;

        protected virtual void OnEnable() 
        {
            if (container.activeInHierarchy)
            {
                MoveIn();
            }
        }
        protected virtual popupBase Show()
        {
            container.SetActive(true);
            return this;
        }

        protected virtual void Hide()
        {
            MoveOut();
        }

        protected virtual void MoveIn()
        {
            container.SetActive(true);
        }

        protected virtual void MoveOut()
        {
        }
        protected virtual void OnDisable() 
        {
        }
    }
}