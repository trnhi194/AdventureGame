using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame
{
    public class GameMainMenuScene : sceneBase
    {
        [SerializeField] private GameObject gameTitle;
        [SerializeField] private GameObject menu;
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnOption;
        [SerializeField] private Button btnQuit;
        [SerializeField] private GameObject knight;
        [SerializeField] private Animator knightAnim;

        protected override void InitScene()
        {
            base.InitScene();
        }
        protected override void InitEvent()
        {
            btnPlay.onClick.AddListener(OnButtonPlayClick);
            btnOption.onClick.AddListener(OnButtonOptionClick);
            btnQuit.onClick.AddListener(OnApplicationQuit);
        }

        private void OnButtonPlayClick()
        {
            Debug.LogWarning("PLAY");
        }

        private void OnButtonOptionClick()
        {
            Debug.LogWarning("OPTION");
        }

        private void OnApplicationQuit()
        {

        }

        protected override void MoveIn()
        {
            btnPlay.transform.localScale = Vector3.zero;
            btnOption.transform.localScale = Vector3.zero;
            btnQuit.transform.localScale = Vector3.zero;
            gameTitle.transform.localPosition = new Vector3(0f, -500f, 0f);
            knight.transform.localPosition = new Vector3(-1080f, -442f, 0f);
            knightAnim.SetInteger(Constant.PLAYER_WALK, 1);
            knightAnim.SetBool(Constant.PLAYER_GROUNDED, true);
            knight.transform.DOLocalMoveX(-500, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                knightAnim.SetTrigger(Constant.PLAYER_ATTACK1);
                knightAnim.SetInteger(Constant.PLAYER_WALK, 0);

                gameTitle.transform.DOLocalMoveY(250f, 2f).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    btnPlay.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBounce).OnComplete(() =>
                    {
                        btnOption.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBounce).OnComplete(() =>
                        {
                            btnQuit.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBounce);
                            knightAnim.SetTrigger()
                        });
                    });
                });
            });
            
        }

        protected override void MoveOut()
        {
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
