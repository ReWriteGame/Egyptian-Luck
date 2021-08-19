using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite player1;
    [SerializeField] private Sprite player2;

    [SerializeField] private SpriteRenderer value;
    public bool isBusy = false;

    public SpriteRenderer Value { get => value; private set => this.value = value; }
    public Sprite Player1 { get => player1; private set => player1 = value; }
    public Sprite Player2 { get => player2; private set => player2 = value; }

    public void movePlayer1()
    {
        isBusy = true;
        value.sprite = player1;
        lockCell();
    }
    public void movePlayer2()
    {
        isBusy = true;
        value.sprite = player2;
        lockCell();
    }

    private void Reset()
    {
        value = null;
        isBusy = false;
    }

    public void lockCell()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
