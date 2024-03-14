using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Mirror.SimpleWeb;
using System;
using Newtonsoft.Json;
using UnityEditor;
using Defective.JSON;
using Mirror;

public class RestAPIController : MonoBehaviour
{
    private readonly string dbURL = "172.30.1.41/api";
    private readonly string urlLogin = "/login.php";
    private readonly string urlPoint = "/point.php";
    private readonly string urlRanking = "/ranking";
    private readonly string urlContent = "/content";

    string responseData = "";
    ResponseResult result = new ResponseResult();
    string basicKey = "AmEDb3EKroi9Kd6MoeLQ";
    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif

    }


    void Start()
    {
    }
    #region 리퀘스트 버튼
    public void LoginBtn()
    {
        string url = dbURL + urlLogin;
        RequestLogin request = new RequestLogin();
        request.id = "test1";
        request.pwd = "qwer1234";
        request.key = basicKey;

        WWWForm form = new WWWForm();
        form.AddField("userid", request.id);
        form.AddField("userpw", request.pwd);
        form.AddField("key", request.key);

        StartCoroutine(Post(url, form, SetJsonLogin));
    }

    public void SavePointBtn()
    {
        string url = dbURL + urlPoint;
        RequestMissionPoint request = new RequestMissionPoint();
        request.id = "test1";
        request.point = 10;     //클라부분은 포인트 합산해서 업뎃해야됨
        request.missionId = "DD_FLOOR998";
        request.missionType = 3;
        request.key = basicKey;

        WWWForm form = new WWWForm();
        form.AddField("userid", request.id);
        form.AddField("point", request.point);
        form.AddField("mission_id", request.missionId);
        form.AddField("misstion_type", request.missionType);
        form.AddField("mode", "save");
        form.AddField("key", request.key);

        StartCoroutine(Post(url, form, SetJsonSavePoint));
    }

    public void UsePointBtn()
    {
        string url = dbURL + urlPoint;
        RequestMissionPoint request = new RequestMissionPoint();
        request.id = "test1";
        request.point = 5;     //클라부분은 포인트 합산해서 업뎃해야됨
        request.missionId = "DD_DISPLAY";
        request.missionType = 1;
        request.key = basicKey;

        WWWForm form = new WWWForm();
        form.AddField("userid", request.id);
        form.AddField("point", request.point);
        form.AddField("mission_id", request.missionId);
        form.AddField("misstion_type", request.missionType);
        form.AddField("mode", "used");
        form.AddField("key", request.key);

        StartCoroutine(Post(url, form, SetJsonUsePoint));
    }

    public void GetSoloRankBtn()
    {
        string url = dbURL + urlRanking;
        RequestRanking request = new RequestRanking();
        request.id = "test1";
        request.key = basicKey;

        WWWForm form = new WWWForm();
        form.AddField("userid", request.id);
        form.AddField("key", request.key);

        StartCoroutine(Post(url, form, SetJsonSoloRank));
    }

    public void GetAllRankBtn()
    {
        string url = dbURL + urlRanking;

        WWWForm form = new WWWForm();
        form.AddField("key", basicKey);

        StartCoroutine(Post(url, form, SetJsonAllRank));
    }
    public void GetExhibitionDataBtn()
    {
        string url = dbURL + urlContent;
        RequestMissionPoint request = new RequestMissionPoint();
        
        WWWForm form = new WWWForm();
        form.AddField("ca_id", "DD_DISPLAY");
        form.AddField("key", basicKey);

        StartCoroutine(Post(url, form, SetJsonExhibition));
    }
    #endregion
    IEnumerator Post(string pUrl, WWWForm pParam, Action pSucCallback)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(pUrl, pParam))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                responseData = www.downloadHandler.text;
                Debug.Log(responseData);

                pSucCallback();
            }
        }           
    }

    #region 응답 콜백
    #region 공통 response
    public void SetJsonResponse()
    {
        JSONObject jsonObj = new JSONObject(responseData);
        result.result = jsonObj.GetField("result");
        result.msg = jsonObj.GetField("msg");
        result.info = jsonObj.GetField("info");
        result.userid = jsonObj.GetField("userid");
        result.rank = jsonObj.GetField("rank");
        result.point = jsonObj.GetField("point");
        if(jsonObj.GetField("ranking") != null)
            result.rankList = jsonObj.GetField("ranking").list;

        if (jsonObj.GetField("info") != null)
            result.exhibitionList = jsonObj.GetField("info").list;
    }
    #endregion

    #region 로그인 콜백
    public void SetJsonLogin()
    {
        SetJsonResponse();

        FR_Member fr_Member = new FR_Member();
        fr_Member.userId = result.info.GetField("USERID").stringValue;
        fr_Member.userName = result.info.GetField("USERNAME").stringValue;
        fr_Member.userNick = result.info.GetField("USERNICK").stringValue;
        fr_Member.schoolName = result.info.GetField("SCHOOL").stringValue;
        fr_Member.schoolCode = result.info.GetField("SCHOOL_CODE").stringValue;
        fr_Member.grade = result.info.GetField("GRADE").intValue;
        fr_Member.classs = result.info.GetField("CLASS").intValue;
        fr_Member.identity = result.info.GetField("ACTION").stringValue == "T" ? Identity.Teacher : result.info.GetField("ACTION").stringValue == "S" ?  Identity.Student : Identity.Admin;
        fr_Member.point = result.info.GetField("POINT").intValue;
        fr_Member.rank = result.info.GetField("RANK").intValue;
        fr_Member.isAdmin = result.info.GetField("ROLE").stringValue == "" ? false : true;
    }
    #endregion

    #region 포인트 적립 콜백
    public void SetJsonSavePoint()
    {
        SetJsonResponse();

        //FR_Member fr_Member = new FR_Member();  //새로 선언이 아니라 기존 게임매니져 데이터를 가져와야함 (이건 임시 테스트용)
        //fr_Member.rank = result.info.GetField("RANK").intValue;
    }
    #endregion

    #region 포인트 사용 콜백
    public void SetJsonUsePoint()
    {
        SetJsonResponse();

        //FR_Member fr_Member = new FR_Member();  //새로 선언이 아니라 기존물 담는 콜라이더 게임매니져 데이터를 가져와야함 (이건 임시 테스트용)
        //fr_Member.userId = result.info.GetField("userid").stringValue;              //이건 기존 아이디 확인용 or 검색
        //fr_Member.point = fr_Member.point - result.info.GetField("point").intValue; //기존 포인트에서 빼기
    }
    #endregion

    #region 솔로랭크 콜백
    public void SetJsonSoloRank()
    {
        SetJsonResponse();

        FR_Member fr_Member = new FR_Member();  //새로 선언이 아니라 기존 게임매니져 데이터를 가져와야함 (이건 임시 테스트용)
        fr_Member.userId = result.userid.stringValue;
        fr_Member.rank = int.Parse(result.rank.stringValue);
        fr_Member.point = int.Parse(result.point.stringValue);
    }
    #endregion
    #region 올 랭크 콜백
    public void SetJsonAllRank()
    {
        SetJsonResponse();

        List<FR_RankData> rankDataList = new List<FR_RankData>();
        for (int i = 0; i < result.rankList.Count; i++)
        {
            FR_RankData rankData = new FR_RankData();
            rankData.userId = result.rankList[i].GetField("userid").stringValue;
            rankData.rank = int.Parse(result.rankList[i].GetField("rank").stringValue);
            rankData.point = int.Parse(result.rankList[i].GetField("point").stringValue);
            
            rankDataList.Add(rankData); 
        }
    }
    #endregion

    #region 겟 전시관 데이터 콜백
    public void SetJsonExhibition()
    {
        SetJsonResponse();

        List<FR_CategoryData> exhibitionList = new List<FR_CategoryData>();
        for (int i = 0; i < result.exhibitionList.Count; i++)
        {
            FR_CategoryData exhibitionListData = new FR_CategoryData();
            exhibitionListData.contentId = result.exhibitionList[i].GetField("con_id").stringValue;
            exhibitionListData.categoryId = result.exhibitionList[i].GetField("ca_id").stringValue;
            exhibitionListData.ord = int.Parse(result.exhibitionList[i].GetField("ord").stringValue);
            exhibitionListData.contentFile = result.exhibitionList[i].GetField("con_file").stringValue;

            exhibitionList.Add(exhibitionListData);
        }
    }

    #endregion
    #endregion
}
