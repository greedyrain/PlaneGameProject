using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankItem : MonoBehaviour
{
    public UILabel rank,playerName,time;

    public void RewriteRank(int rank)
    {
        this.rank.text = rank.ToString();
    }

    public void RewriteName(string name)
    {
        playerName.text = name;
    }

    public void RewriteTime(int time)
    {
        this.time.text = time.ToString();
    }
}
