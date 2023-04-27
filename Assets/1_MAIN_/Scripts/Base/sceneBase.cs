using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  MainGame
{
    [DisallowMultipleComponent]
    public abstract class sceneBase : MonoBehaviour
    {
        [SerializeField] protected GameObject container;
        protected virtual void OnEnable()
        {
            MoveIn();
        }
        protected virtual void OnDisable()
        {
            MoveOut();
        }
        protected virtual void InitScene()
        {

        }
        protected abstract void InitEvent();
        protected abstract void MoveIn();
        protected abstract void MoveOut();
        protected virtual void Show() 
        {

        }
        protected virtual void Hide() 
        {

        }
    }
}
