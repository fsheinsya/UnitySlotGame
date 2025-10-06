using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Symbol
{
    Jackpot,
    Seven,
    Bar,
    Diamond,
    Watermelon,
    Cherry,
    Bell,
    None
}

public class SlotMachine : MonoBehaviour
{
    [Header("UI Components")]
    public Image[] reelImages;        // 3つのリールImage
    public Button[] stopButtons;      // Stopボタン3つ
    public Text resultText;           // 結果表示
    public Text stageText;            // ステージ表示

    [Header("Symbol Sprites")]
    public Sprite jackpotSprite;
    public Sprite sevenSprite;
    public Sprite barSprite;
    public Sprite diamondSprite;
    public Sprite watermelonSprite;
    public Sprite cherrySprite;
    public Sprite bellSprite;
    public Sprite noneSprite;

    private Symbol[] reelSymbols = new Symbol[3];
    private bool[] reelStopped = new bool[3];
    private int currentStage = 1;
    private bool isSpinning = false;

    // 外れパターン一覧（15種類）
    private static readonly Symbol[][] missPatterns = new Symbol[][]
    {
        new Symbol[]{ Symbol.Bar, Symbol.Cherry, Symbol.Bell },
        new Symbol[]{ Symbol.Watermelon, Symbol.Diamond, Symbol.Cherry },
        new Symbol[]{ Symbol.Bell, Symbol.Watermelon, Symbol.Bar },
        new Symbol[]{ Symbol.Diamond, Symbol.Bell, Symbol.Watermelon },
        new Symbol[]{ Symbol.Cherry, Symbol.Diamond, Symbol.Bell },
        new Symbol[]{ Symbol.Watermelon, Symbol.Cherry, Symbol.Bar },
        new Symbol[]{ Symbol.Diamond, Symbol.Watermelon, Symbol.Bell },
        new Symbol[]{ Symbol.Bell, Symbol.Cherry, Symbol.Diamond },
        new Symbol[]{ Symbol.Bar, Symbol.Diamond, Symbol.Watermelon },
        new Symbol[]{ Symbol.Cherry, Symbol.Bell, Symbol.Bar },
        new Symbol[]{ Symbol.Diamond, Symbol.Bar, Symbol.Cherry },
        new Symbol[]{ Symbol.Watermelon, Symbol.Bar, Symbol.Bell },
        new Symbol[]{ Symbol.Cherry, Symbol.Watermelon, Symbol.Diamond },
        new Symbol[]{ Symbol.Bell, Symbol.Diamond, Symbol.Watermelon },
        new Symbol[]{ Symbol.Watermelon, Symbol.Bell, Symbol.Cherry }
    };

    void Start()
    {
        for (int i = 0; i < stopButtons.Length; i++)
        {
            int index = i;
            stopButtons[i].onClick.AddListener(() => StopReel(index));
        }
        UpdateStageText();
    }

    void UpdateStageText()
    {
        stageText.text = $"Stage {currentStage}";
    }

    public void StartSpin()
    {
        if (isSpinning) return;

        isSpinning = true;
        resultText.text = "";
        for (int i = 0; i < 3; i++)
        {
            reelStopped[i] = false;
            StartCoroutine(SpinReel(i));
        }
    }

    private System.Collections.IEnumerator SpinReel(int index)
    {
        while (!reelStopped[index])
        {
            reelSymbols[index] = GetRandomSymbol();
            reelImages[index].sprite = GetSymbolSprite(reelSymbols[index]);
            yield return new WaitForSeconds(0.05f); // 回転速度
        }

        if (reelStopped.All(x => x))
        {
            isSpinning = false;
            CheckResult();
        }
    }

    private void StopReel(int index)
    {
        if (isSpinning)
            reelStopped[index] = true;
    }

    private Symbol GetRandomSymbol()
    {
        var probs = GetStageProbabilities(currentStage);
        float rand = UnityEngine.Random.value;
        float cumulative = 0f;

        foreach (var kvp in probs)
        {
            cumulative += kvp.Value;
            if (rand <= cumulative)
                return kvp.Key;
        }
        return Symbol.None;
    }

    private Sprite GetSymbolSprite(Symbol symbol)
    {
        switch (symbol)
        {
            case Symbol.Jackpot: return jackpotSprite;
            case Symbol.Seven: return sevenSprite;
            case Symbol.Bar: return barSprite;
            case Symbol.Diamond: return diamondSprite;
            case Symbol.Watermelon: return watermelonSprite;
            case Symbol.Cherry: return cherrySprite;
            case Symbol.Bell: return bellSprite;
            default: return noneSprite;
        }
    }

    private void CheckResult()
    {
        if (reelSymbols[0] == reelSymbols[1] && reelSymbols[1] == reelSymbols[2])
        {
            resultText.text = $"🎉 {reelSymbols[0]} HIT!";
            AdvanceStage();
        }
        else
        {
            ShowMissPattern();
        }
    }

    private void ShowMissPattern()
    {
        int patternIndex = UnityEngine.Random.Range(0, missPatterns.Length);
        for (int i = 0; i < 3; i++)
        {
            reelSymbols[i] = missPatterns[patternIndex][i];
            reelImages[i].sprite = GetSymbolSprite(reelSymbols[i]);
        }
        resultText.text = "役ナシ...";
    }

    private void AdvanceStage()
    {
        if (currentStage < 3)
        {
            currentStage++;
            UpdateStageText();
        }
    }

    private Dictionary<Symbol, float> GetStageProbabilities(int stage)
    {
        switch (stage)
        {
            case 1:
                return new Dictionary<Symbol, float>
                {
                    { Symbol.Jackpot, 0.002f },
                    { Symbol.Seven, 0.008f },
                    { Symbol.Bar, 0.04f },
                    { Symbol.Diamond, 0.08f },
                    { Symbol.Watermelon, 0.10f },
                    { Symbol.Cherry, 0.15f },
                    { Symbol.Bell, 0.25f },
                    { Symbol.None, 0.37f }
                };
            case 2:
                return new Dictionary<Symbol, float>
                {
                    { Symbol.Jackpot, 0.005f },
                    { Symbol.Seven, 0.015f },
                    { Symbol.Bar, 0.06f },
                    { Symbol.Diamond, 0.10f },
                    { Symbol.Watermelon, 0.13f },
                    { Symbol.Cherry, 0.16f },
                    { Symbol.Bell, 0.23f },
                    { Symbol.None, 0.30f }
                };
            case 3:
                return new Dictionary<Symbol, float>
                {
                    { Symbol.Jackpot, 0.01f },
                    { Symbol.Seven, 0.03f },
                    { Symbol.Bar, 0.08f },
                    { Symbol.Diamond, 0.12f },
                    { Symbol.Watermelon, 0.15f },
                    { Symbol.Cherry, 0.17f },
                    { Symbol.Bell, 0.20f },
                    { Symbol.None, 0.24f }
                };
            default:
                throw new ArgumentException("Stage must be 1–3");
        }
    }
}
