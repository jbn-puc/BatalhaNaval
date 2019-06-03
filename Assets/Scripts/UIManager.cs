using System;
using Lunari.Tsuki.Singletons;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    public Text statusDisplay;
    public HorizontalLayoutGroup group;
    public UnitPlacer placerPrefab;
    private UnitPlacer[] placers;

    private void Update() {
        var gm = GameManager.Instance;
        string msg;
        switch (gm.state) {
            case GameState.PlacingPlayer1:
                msg = "Player 1, posicione sua armada";
                break;
            case GameState.PlacingPlayer2:
                msg = "Player 2, posicione sua armada";
                break;
            case GameState.Player1:
                msg = "Vez do jogador 1";
                break;
            case GameState.Player2:
                msg = "Vez do jogador 2";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        statusDisplay.text = msg;
        if (gm.state == GameState.PlacingPlayer1 || gm.state == GameState.PlacingPlayer2) {
            UpdatePlacement(gm);
        }
    }

    private void Start() {
        var gm = GameManager.Instance;
        foreach (var unit in gm.deck.availableUnits) {
            var p = Instantiate(placerPrefab, @group.transform);
            p.Init(unit);
        }
    }

    private void UpdatePlacement(GameManager gm) { }
}