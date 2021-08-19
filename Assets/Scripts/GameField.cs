using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameField : MonoBehaviour
{
    [SerializeField] private Vector2Int size;
    [SerializeField] private Cell []field;

    public UnityEvent winEvent;
    public UnityEvent loseEvent;

    public void checkGamePlayer1()
    {
        if (field[0].isBusy && field[0].Value.sprite == field[4].Value.sprite && field[4].Value.sprite == field[8].Value.sprite) understandWhoWin(field[0]);
        if (field[2].isBusy && field[2].Value.sprite == field[4].Value.sprite && field[4].Value.sprite == field[6].Value.sprite) understandWhoWin(field[2]);
        if (field[0].isBusy && field[0].Value.sprite == field[3].Value.sprite && field[3].Value.sprite == field[6].Value.sprite) understandWhoWin(field[0]);
        if (field[1].isBusy && field[1].Value.sprite == field[4].Value.sprite && field[4].Value.sprite == field[7].Value.sprite) understandWhoWin(field[1]);
        if (field[2].isBusy && field[2].Value.sprite == field[3].Value.sprite && field[3].Value.sprite == field[8].Value.sprite) understandWhoWin(field[2]);
        if (field[0].isBusy && field[0].Value.sprite == field[1].Value.sprite && field[1].Value.sprite == field[2].Value.sprite) understandWhoWin(field[0]);
        if (field[3].isBusy && field[3].Value.sprite == field[4].Value.sprite && field[4].Value.sprite == field[5].Value.sprite) understandWhoWin(field[3]);
        if (field[6].isBusy && field[6].Value.sprite == field[7].Value.sprite && field[7].Value.sprite == field[8].Value.sprite) understandWhoWin(field[6]);
    }
    private void understandWhoWin(Cell obj)
    {
        if (obj.Value.sprite == obj.Player1) winEvent?.Invoke();
        else if (obj.Value.sprite == obj.Player2) loseEvent?.Invoke();
    }

    public void randomMoveEnemy()
    {
        int index = Random.Range(0, field.Length);
        if (!field[index].isBusy) field[index].movePlayer2();
        else doMove();
    }

    private void doMove()
    {
        for (int i = 0; i < field.Length; i++)
        {
            if (!field[i].isBusy)
            {
                field[i].movePlayer2();
                return;
            }
            if (i == field.Length - 1) loseEvent?.Invoke();
        }
    }
}
