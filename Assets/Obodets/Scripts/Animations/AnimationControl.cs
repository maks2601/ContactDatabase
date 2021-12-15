using DG.Tweening;
using UnityEngine;

namespace Obodets.Scripts.Animations
{
    public static class AnimationControl
    {
        public static void Hide(this Transform element, float time)
        {
            element.DOMoveX(element.position.x + Screen.width, time);
        }

        public static void FloatingTo(this Transform element, float positionX, float time = 0.6f)
        {
            element.DOMoveX(positionX, time);
        }
    }
}
