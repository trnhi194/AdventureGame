using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame
{
    public class GameOverPopup : popupBase
    {
        [SerializeField] private Button btnMainMenu;
        [SerializeField] private GameObject knight;
        [SerializeField] private Animator knightAnim;

        protected override void OnEnable()
        {
            base.OnEnable();
            btnMainMenu.onClick.AddListener(() =>
            {
                Hide();
            });
        }

        protected override popupBase Show()
        {
            return base.Show();
        }

        protected override void MoveIn()
        {
            base.MoveIn();
            txtTitle.transform.localPosition = new Vector3(0f, 600f, 0f);
            btnMainMenu.transform.localPosition = new Vector3(0f, 600f, 0f);
            knightAnim.SetTrigger(Constant.PLAYER_Death);
            StartCoroutine(ShowMenu());
        }

        protected override void MoveOut()
        {
            container.transform.DOScale(Vector3.zero, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                Hide();
            });
        }

        IEnumerator ShowMenu()
        {
            yield return new WaitForSeconds(1f);
            txtTitle.transform.DOLocalMoveY(150f, 1f).SetEase(Ease.Linear);
            btnMainMenu.transform.DOLocalMoveY(0f, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                btnMainMenu.transform.DOScale(Vector3.one * 1.1f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    btnMainMenu.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.Linear);
                }).SetLoops(-1, LoopType.Yoyo);
            });
        }

        protected override void OnDisable()
        {
            btnMainMenu.onClick.RemoveAllListeners();
        }
    }
}
