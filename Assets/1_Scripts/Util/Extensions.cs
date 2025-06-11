using System.Collections;
using DG.Tweening;
using UnityEngine;

public static class Extensions
{
    // Extension: Transform
    public static T FindChildByName<T>(this Transform trans, string name) where T : Component
    {
        // 비활성화된 것까지 전부 
        T[] children = trans.GetComponentsInChildren<T>(true);
        foreach (T child in children)
        {
            if (child.name == name)
            {
                return child;
            }
        }
        return null;
    }
    
    
    // Extension: enum StatType 
    public static string ToKor(this StatType type)
    {
        return type switch
        {
            StatType.Hp => "체력",
            StatType.Atk => "공격력",
            StatType.Def => "방어력",
            _ => string.Empty
        };
    }
    
    // Extension: Canvas Group
    public static void SetAlpha(this CanvasGroup canvasGroup, bool active)
    {
        if (active)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
    
    private static void AnimatePopup(CanvasGroup canvasGroup, RectTransform rectTr, RectTransform.Axis axis, float startPosValue, float destination, float finalAlpha)
    {
        // 초기화: DOTween 제거
        canvasGroup.DOKill();
        rectTr.DOKill();
        
        // finalAlpha = 0 => true, finalAlpha = 1 => false
        canvasGroup.SetAlpha(finalAlpha < 0.5f);
        
        // 가로, 세로에 따라
        switch (axis)
        {
            case RectTransform.Axis.Horizontal:
                rectTr.anchoredPosition = new Vector2(startPosValue, rectTr.anchoredPosition.y);
                rectTr.DOAnchorPosX(destination, 0.5f).From(rectTr.anchoredPosition);
                break;
            case RectTransform.Axis.Vertical:
                rectTr.anchoredPosition = new Vector2(rectTr.anchoredPosition.x, startPosValue);
                rectTr.DOAnchorPosY(destination, 0.5f).From(rectTr.anchoredPosition);
                break;
            default:
                MyDebug.Log("Animation Failed: AnimatePopup");
                return;
        }

        DOVirtual.DelayedCall(0.1f, () =>
        {
            // 2/5 정도 실행됐을 때, Fade 실행
            // finalAlpha = 0 => false, finalAlpha = 1 => true
            canvasGroup.DOFade(finalAlpha, 0.3f).onComplete += () => canvasGroup.SetAlpha(finalAlpha > 0.5f);
        });
    }
    
    public static void OpenPopupAnimation(this CanvasGroup canvasGroup, RectTransform rectTr, RectTransform.Axis axis, float startPosValue, float destination)
        => AnimatePopup(canvasGroup, rectTr, axis, startPosValue, destination, 1f);

    public static void ClosePopupAnimation(this CanvasGroup canvasGroup, RectTransform rectTr, RectTransform.Axis axis, float startPosValue, float destination)
        => AnimatePopup(canvasGroup, rectTr, axis, startPosValue, destination, 0f);
}