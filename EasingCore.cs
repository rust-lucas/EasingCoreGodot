/*
 * EasingCore (https://github.com/setchi/EasingCore)
 * Copyright (c) 2019 setchi
 * Licensed under MIT (https://github.com/setchi/EasingCore/blob/master/LICENSE)
 */

namespace EasingCore
{
    public enum Ease
    {
        Linear,
        InBack,
        InBounce,
        InCirc,
        InCubic,
        InElastic,
        InExpo,
        InQuad,
        InQuart,
        InQuint,
        InSine,
        OutBack,
        OutBounce,
        OutCirc,
        OutCubic,
        OutElastic,
        OutExpo,
        OutQuad,
        OutQuart,
        OutQuint,
        OutSine,
        InOutBack,
        InOutBounce,
        InOutCirc,
        InOutCubic,
        InOutElastic,
        InOutExpo,
        InOutQuad,
        InOutQuart,
        InOutQuint,
        InOutSine,
    }

    public delegate float EasingFunction(float t);

    public static class Easing
    {
        /// <summary>
        /// Gets the easing function
        /// </summary>
        /// <param name="type">Ease type</param>
        /// <returns>Easing function</returns>
        public static EasingFunction Get(Ease type)
        {
            switch (type)
            {
                case Ease.Linear: return Linear;
                case Ease.InBack: return InBack;
                case Ease.InBounce: return InBounce;
                case Ease.InCirc: return InCirc;
                case Ease.InCubic: return InCubic;
                case Ease.InElastic: return InElastic;
                case Ease.InExpo: return InExpo;
                case Ease.InQuad: return InQuad;
                case Ease.InQuart: return InQuart;
                case Ease.InQuint: return InQuint;
                case Ease.InSine: return InSine;
                case Ease.OutBack: return OutBack;
                case Ease.OutBounce: return OutBounce;
                case Ease.OutCirc: return OutCirc;
                case Ease.OutCubic: return OutCubic;
                case Ease.OutElastic: return OutElastic;
                case Ease.OutExpo: return OutExpo;
                case Ease.OutQuad: return OutQuad;
                case Ease.OutQuart: return OutQuart;
                case Ease.OutQuint: return OutQuint;
                case Ease.OutSine: return OutSine;
                case Ease.InOutBack: return InOutBack;
                case Ease.InOutBounce: return InOutBounce;
                case Ease.InOutCirc: return InOutCirc;
                case Ease.InOutCubic: return InOutCubic;
                case Ease.InOutElastic: return InOutElastic;
                case Ease.InOutExpo: return InOutExpo;
                case Ease.InOutQuad: return InOutQuad;
                case Ease.InOutQuart: return InOutQuart;
                case Ease.InOutQuint: return InOutQuint;
                case Ease.InOutSine: return InOutSine;
                default: return Linear;
            }

            float Linear(float t) => t;

            float InBack(float t) => t * t * t - t * Godot.Mathf.Sin(t * Godot.Mathf.Pi);

            float OutBack(float t) => 1f - InBack(1f - t);

            float InOutBack(float t) =>
                t < 0.5f
                    ? 0.5f * InBack(2f * t)
                    : 0.5f * OutBack(2f * t - 1f) + 0.5f;

            float InBounce(float t) => 1f - OutBounce(1f - t);

            float OutBounce(float t) =>
                t < 4f / 11.0f ?
                    (121f * t * t) / 16.0f :
                t < 8f / 11.0f ?
                    (363f / 40.0f * t * t) - (99f / 10.0f * t) + 17f / 5.0f :
                t < 9f / 10.0f ?
                    (4356f / 361.0f * t * t) - (35442f / 1805.0f * t) + 16061f / 1805.0f :
                    (54f / 5.0f * t * t) - (513f / 25.0f * t) + 268f / 25.0f;

            float InOutBounce(float t) =>
                t < 0.5f
                    ? 0.5f * InBounce(2f * t)
                    : 0.5f * OutBounce(2f * t - 1f) + 0.5f;

            float InCirc(float t) => 1f - Godot.Mathf.Sqrt(1f - (t * t));

            float OutCirc(float t) => Godot.Mathf.Sqrt((2f - t) * t);

            float InOutCirc(float t) =>
                t < 0.5f
                    ? 0.5f * (1 - Godot.Mathf.Sqrt(1f - 4f * (t * t)))
                    : 0.5f * (Godot.Mathf.Sqrt(-((2f * t) - 3f) * ((2f * t) - 1f)) + 1f);

            float InCubic(float t) => t * t * t;

            float OutCubic(float t) => InCubic(t - 1f) + 1f;

            float InOutCubic(float t) =>
                t < 0.5f
                    ? 4f * t * t * t
                    : 0.5f * InCubic(2f * t - 2f) + 1f;

            float InElastic(float t) => Godot.Mathf.Sin(13f * (Godot.Mathf.Pi * 0.5f) * t) * Godot.Mathf.Pow(2f, 10f * (t - 1f));

            float OutElastic(float t) => Godot.Mathf.Sin(-13f * (Godot.Mathf.Pi * 0.5f) * (t + 1)) * Godot.Mathf.Pow(2f, -10f * t) + 1f;

            float InOutElastic(float t) =>
                t < 0.5f
                    ? 0.5f * Godot.Mathf.Sin(13f * (Godot.Mathf.Pi * 0.5f) * (2f * t)) * Godot.Mathf.Pow(2f, 10f * ((2f * t) - 1f))
                    : 0.5f * (Godot.Mathf.Sin(-13f * (Godot.Mathf.Pi * 0.5f) * ((2f * t - 1f) + 1f)) * Godot.Mathf.Pow(2f, -10f * (2f * t - 1f)) + 2f);

            float InExpo(float t) => Godot.Mathf.IsEqualApprox(0.0f, t) ? t : Godot.Mathf.Pow(2f, 10f * (t - 1f));

            float OutExpo(float t) => Godot.Mathf.IsEqualApprox(1.0f, t) ? t : 1f - Godot.Mathf.Pow(2f, -10f * t);

            float InOutExpo(float v) =>
                Godot.Mathf.IsEqualApprox(0.0f, v) || Godot.Mathf.IsEqualApprox(1.0f, v)
                    ? v
                    : v < 0.5f
                        ?  0.5f * Godot.Mathf.Pow(2f, (20f * v) - 10f)
                        : -0.5f * Godot.Mathf.Pow(2f, (-20f * v) + 10f) + 1f;

            float InQuad(float t) => t * t;

            float OutQuad(float t) => -t * (t - 2f);

            float InOutQuad(float t) =>
                t < 0.5f
                    ?  2f * t * t
                    : -2f * t * t + 4f * t - 1f;

            float InQuart(float t) => t * t * t * t;

            float OutQuart(float t)
            {
                var u = t - 1f;
                return u * u * u * (1f - t) + 1f;
            }

            float InOutQuart(float t) =>
                t < 0.5f
                    ? 8f * InQuart(t)
                    : -8f * InQuart(t - 1f) + 1f;

            float InQuint(float t) => t * t * t * t * t;

            float OutQuint(float t) => InQuint(t - 1f) + 1f;

            float InOutQuint(float t) =>
                t < 0.5f
                    ? 16f * InQuint(t)
                    : 0.5f * InQuint(2f * t - 2f) + 1f;

            float InSine(float t) => Godot.Mathf.Sin((t - 1f) * (Godot.Mathf.Pi * 0.5f)) + 1f;

            float OutSine(float t) => Godot.Mathf.Sin(t * (Godot.Mathf.Pi * 0.5f));

            float InOutSine(float t) => 0.5f * (1f - Godot.Mathf.Cos(t * Godot.Mathf.Pi));
        }
    }
}
