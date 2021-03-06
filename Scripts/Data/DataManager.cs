using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public int planeKey;
    public int gameTime;//游戏时间，在GamePanel显示时清0，并随着Update增加；
    private static DataManager instance = new DataManager();
    public static DataManager Instance
    {
        get { return instance; }
    }

    private HerosInfo herosInfo;
    public HerosInfo HerosInfo
    {
        get { return herosInfo; }
    }

    private BulletsInfo bulletsInfo;
    public BulletsInfo BulletsInfo
    {
        get { return bulletsInfo; }
    }

    private RankList rankInfo;
    public RankList RankInfo
    {
        get { return rankInfo; }
    }

    private SoundData soundData;
    public SoundData SoundData
    {
        get { return soundData; }
    }

    private FirePosInfo firePosInfo;
    public FirePosInfo FirePosInfo
    {
        get { return firePosInfo; }
    }

    private DataManager()
    {
        herosInfo = XMLDataManager.Instance.LoadData(typeof(HerosInfo),"HerosInfo") as HerosInfo;
        rankInfo = XMLDataManager.Instance.LoadData(typeof(RankList), "RankInfo") as RankList;
        soundData = XMLDataManager.Instance.LoadData(typeof(SoundData), "SoundData") as SoundData;
        bulletsInfo = XMLDataManager.Instance.LoadData(typeof(BulletsInfo), "BulletsInfo") as BulletsInfo;
        firePosInfo = XMLDataManager.Instance.LoadData(typeof(FirePosInfo), "FirePosInfo") as FirePosInfo;
    }

    public void SetSoundVolume(float value)
    {
        soundData.soundVolume = value;
    }

    public void SetMusicVolume(float value)
    {
        soundData.musicVolume = value;
    }

    public void SetSoundMute(bool mute)
    {
        soundData.soundMute = mute;
    }

    public void SetMusicMute(bool mute)
    {
        soundData.musicMute = mute;
    }

    public void UpdateRankList(int time, string name)
    {
        RankData data = new RankData();
        data.name = name;
        data.time = time;
        rankInfo.rankList.Add(data);
        rankInfo.rankList.Sort((a,b)=> { return a.time > b.time ? -1 : 1; });//排序-1将a放在前，1将a放在后，0则不变；
        for (int i = 0; i < rankInfo.rankList.Count; i++)
        {
            rankInfo.rankList[i].rank = i + 1;
        }
        XMLDataManager.Instance.SaveData(rankInfo, "RankInfo");
    }
}
