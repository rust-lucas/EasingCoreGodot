/*
 * EasingCore (https://github.com/setchi/EasingCore)
 * Copyright (c) 2019 setchi
 * Licensed under MIT (https://github.com/setchi/EasingCore/blob/master/LICENSE)
 * Edits (c) 2023 RUST LLC
 */

using Godot;

namespace EasingCore;

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
    InOutSine
}

public delegate float EasingFunction(float t);

public static class Easing
{
    /// <summary>
    ///     Gets the easing function
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

        float Linear(float t)
        {
            return t;
        }

        float InBack(float t)
        {
            return t * t * t - t * Mathf.Sin(t * Mathf.Pi);
        }

        float OutBack(float t)
        {
            return 1f - InBack(1f - t);
        }

        float InOutBack(float t)
        {
            return t < 0.5f
                ? 0.5f * InBack(2f * t)
                : 0.5f * OutBack(2f * t - 1f) + 0.5f;
        }

        float InBounce(float t)
        {
            return 1f - OutBounce(1f - t);
        }

        float OutBounce(float t)
        {
            return t < 4f / 11.0f ? 121f * t * t / 16.0f :
                t < 8f / 11.0f ? 363f / 40.0f * t * t - 99f / 10.0f * t + 17f / 5.0f :
                t < 9f / 10.0f ? 4356f / 361.0f * t * t - 35442f / 1805.0f * t + 16061f / 1805.0f :
                54f / 5.0f * t * t - 513f / 25.0f * t + 268f / 25.0f;
        }

        float InOutBounce(float t)
        {
            return t < 0.5f
                ? 0.5f * InBounce(2f * t)
                : 0.5f * OutBounce(2f * t - 1f) + 0.5f;
        }

        float InCirc(float t)
        {
            return 1f - Mathf.Sqrt(1f - t * t);
        }

        float OutCirc(float t)
        {
            return Mathf.Sqrt((2f - t) * t);
        }

        float InOutCirc(float t)
        {
            return t < 0.5f
                ? 0.5f * (1 - Mathf.Sqrt(1f - 4f * (t * t)))
                : 0.5f * (Mathf.Sqrt(-(2f * t - 3f) * (2f * t - 1f)) + 1f);
        }

        float InCubic(float t)
        {
            return t * t * t;
        }

        float OutCubic(float t)
        {
            return InCubic(t - 1f) + 1f;
        }

        float InOutCubic(float t)
        {
            return t < 0.5f
                ? 4f * t * t * t
                : 0.5f * InCubic(2f * t - 2f) + 1f;
        }

        float InElastic(float t)
        {
            return Mathf.Sin(13f * (Mathf.Pi * 0.5f) * t) * Mathf.Pow(2f, 10f * (t - 1f));
        }

        float OutElastic(float t)
        {
            return Mathf.Sin(-13f * (Mathf.Pi * 0.5f) * (t + 1)) * Mathf.Pow(2f, -10f * t) + 1f;
        }

        float InOutElastic(float t)
        {
            return t < 0.5f
                ? 0.5f * Mathf.Sin(13f * (Mathf.Pi * 0.5f) * (2f * t)) *
                  Mathf.Pow(2f, 10f * (2f * t - 1f))
                : 0.5f * (Mathf.Sin(-13f * (Mathf.Pi * 0.5f) * (2f * t - 1f + 1f)) *
                    Mathf.Pow(2f, -10f * (2f * t - 1f)) + 2f);
        }

        float InExpo(float t)
        {
            return Mathf.IsEqualApprox(0.0f, t) ? t : Mathf.Pow(2f, 10f * (t - 1f));
        }

        float OutExpo(float t)
        {
            return Mathf.IsEqualApprox(1.0f, t) ? t : 1f - Mathf.Pow(2f, -10f * t);
        }

        float InOutExpo(float v)
        {
            return Mathf.IsEqualApprox(0.0f, v) || Mathf.IsEqualApprox(1.0f, v)
                ? v
                : v < 0.5f
                    ? 0.5f * Mathf.Pow(2f, 20f * v - 10f)
                    : -0.5f * Mathf.Pow(2f, -20f * v + 10f) + 1f;
        }

        float InQuad(float t)
        {
            return t * t;
        }

        float OutQuad(float t)
        {
            return -t * (t - 2f);
        }

        float InOutQuad(float t)
        {
            return t < 0.5f
                ? 2f * t * t
                : -2f * t * t + 4f * t - 1f;
        }

        float InQuart(float t)
        {
            return t * t * t * t;
        }

        float OutQuart(float t)
        {
            float u = t - 1f;
            return u * u * u * (1f - t) + 1f;
        }

        float InOutQuart(float t)
        {
            return t < 0.5f
                ? 8f * InQuart(t)
                : -8f * InQuart(t - 1f) + 1f;
        }

        float InQuint(float t)
        {
            return t * t * t * t * t;
        }

        float OutQuint(float t)
        {
            return InQuint(t - 1f) + 1f;
        }

        float InOutQuint(float t)
        {
            return t < 0.5f
                ? 16f * InQuint(t)
                : 0.5f * InQuint(2f * t - 2f) + 1f;
        }

        float InSine(float t)
        {
            return Mathf.Sin((t - 1f) * (Mathf.Pi * 0.5f)) + 1f;
        }

        float OutSine(float t)
        {
            return Mathf.Sin(t * (Mathf.Pi * 0.5f));
        }

        float InOutSine(float t)
        {
            return 0.5f * (1f - Mathf.Cos(t * Mathf.Pi));
        }
    }
}