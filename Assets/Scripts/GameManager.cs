using System.Collections;
using Lunari.Tsuki;
using Lunari.Tsuki.Singletons;
using UnityEngine;

public enum GameState
{
    PlacingPlayer1,
    PlacingPlayer2,
    Player1,
    Player2
}

public class Field
{
    public GridSlot[,] Grid { get; private set; }
    public byte width, height;
    public Field(GameManager manager)
    {
        width = manager.width;
        height = manager.height;
        var layout = manager.layout;
        var slotPrefab = manager.slotPrefab;
        Grid = new GridSlot[width, height];
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            { 
                var obj = Grid[x, y] = Object.Instantiate(slotPrefab, layout.transform);
                obj.transform.position = layout.GetCellCenterWorld(new Vector3Int(x, y, 0));
            }
        }
        foreach (var unit in
        manager.deck.availableUnits)
        {
            bool placed = false;
            while (!placed)
            {
                var baseX = Random.Range(0, width);
                var baseY = Random.Range(0, height);
                if (unit.structure.CanPlaceIn(this, baseX, baseY))
                {
                    for (var x = 0; x < unit.structure.width; x++)
                    {
                        for (var y = 0; y < unit.structure.height; y++)
                        {
                            Grid[baseX + x, baseY + y].unit = unit;
                        }
                    }
                    Debug.Log(baseX + " -> " + (baseX + unit.structure.width)+", "+ baseY + " -> " + (baseY + unit.structure.height)+ ": "+unit);
                    placed = true;
                }
            }
        }
    }

    public void SetVisible(bool visible)
    {
        foreach (var slot in Grid)
        {
            slot.gameObject.SetActive(visible);
        }
    }
}

public class GameManager : Singleton<GameManager>
{
    public GridSlot slotPrefab;
    public Field player1, player2;
    public Grid layout;
    public GameState state;
    public byte width, height;
    public Vector2Int selected;
    public bool allowInput = true;
    public Deck deck;
    private Coroutine awaitRoutine;

    private void Update()
    {
        var c = Camera.main;
        if (c == null)
        {
            return;
        }

        var ray = c.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        var wp = hit.point;
        selected = (Vector2Int)layout.WorldToCell(wp);
        if ((state == GameState.Player1 || state == GameState.Player2) && allowInput)
        {

            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            CurrentField.Grid[selected.x, selected.y].isExposed = true;

            Coroutines.ReplaceCoroutine(ref awaitRoutine, this, AwaitTurn());
        }
    }

    private IEnumerator AwaitTurn()
    {
        allowInput = false;
        yield return new WaitForSeconds(1);
        switch (state)
        {
            case GameState.Player1:
                player1.SetVisible(false);
                break;
            case GameState.Player2:
                player2.SetVisible(false);
                break;
        }

        yield return new WaitForSeconds(1);
        switch (state)
        {
            case GameState.Player1:
                state = GameState.Player2;
                player2.SetVisible(true);
                break;
            case GameState.Player2:
                state = GameState.Player1;
                player1.SetVisible(true);
                break;
        }

        allowInput = true;
    }

    private void Start()
    {
        player1 = new Field(this);
        player2 = new Field(this);
        //player1.SetVisible(tr);
        player2.SetVisible(false);
    }

    public Field CurrentField
    {
        get
        {
            if (state == GameState.Player1)
            {
                return player1;
            }

            if (state == GameState.Player2)
            {
                return player2;
            }

            return null;
        }
    }
}