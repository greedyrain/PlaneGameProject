using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
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
    private DataManager()
    {
        herosInfo = XMLDataManager.Instance.LoadData(typeof(HerosInfo),"HerosInfo") as HerosInfo;
        rankInfo = XMLDataManager.Instance.LoadData(typeof(RankList), "RankList") as RankList;
        soundData = XMLDataManager.Instance.LoadData(typeof(SoundData), "SoundData") as SoundData;
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
        rankInfo.rankList.Sort((a,b)=> { return a.time < b.time ? -1 : 1; });//排序-1将a放在前，1将a放在后，0则不变；
    }
}
