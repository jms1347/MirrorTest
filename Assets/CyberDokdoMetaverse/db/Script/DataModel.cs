using Defective.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

#region DataModel
public enum Identity
{
    Teacher = 0,
    Student = 1,
    Admin = 2
}
#region 현재 접속자 정보
[System.Serializable]
public class FR_Connect
{
    public string userId;
    public int contentId;
    public DateTime logDate;
}
#endregion
#region 포인트 적립 및 사용
[System.Serializable]
public class FR_Point_Log
{
    public string userId;
    public string contentArea;
    public int usePoint;

}
#endregion
#region 카테고리 관리
[System.Serializable]
public class FR_Category
{
    public string categoryId;
    public string categoryName;
    public string categoryType;     //1 - 동영상, 2-360VR, 3-게임
    public int categoryEA;          //입력가능한 파일 수
}
#endregion
#region 전시품 관리
[System.Serializable]
public class FR_Content
{
    public int contentId;
    public string categoryId;
    public int contentOrder;
    public string contentFile;
    public bool isView; // 1 : 표시, 0 : 표시하지 않음
    public DateTime contentRegistrationDate;
}
#endregion
#region 회원정보
[System.Serializable]
public class FR_Member
{
    public string userId;
    public string userName;
    public string userNick;
    public string schoolName;
    public string schoolCode;
    public int grade;
    public int classs;
    public Identity identity;   //선생 : T , 학생 : S, 관리자(학교소속이아님) : N
    public int point;
    public int rank;
    public bool isAdmin;    //관리 권한 여부
}
#endregion

#region 랭킹
public class FR_RankData
{
    public int rank;
    public string userId;
    public int point;
}
#endregion

#region 카테고리 데이터
public class FR_CategoryData
{
    public string contentId;
    public string categoryId;
    public int ord;
    public string contentFile;
}
#endregion

#region 미션 결과
[System.Serializable]
public class FR_Mission_Result
{
    public string userId;
    public string missionId;
    public int missionType; // 1 : 영상시청, 2: 360도VR, 3:게임
    public int point;
    public DateTime missionResultRegistrationDate;
}

#endregion
#endregion
#region web reqeust
[System.Serializable]
public class RequestLogin
{
    public string id;
    public string pwd;
    public string key;
}
[System.Serializable]
public class RequestMissionPoint
{
    public string id;
    public int point;
    public string missionId;
    public int missionType;
    public string key;
}
[System.Serializable]
public class RequestRanking
{
    public string id;
    public string key;
}

#endregion
#region web response
[System.Serializable]
public class ResponseResult
{
    public JSONObject result;
    public JSONObject msg;
    public JSONObject info;
    public JSONObject userid;
    public JSONObject rank;
    public JSONObject point;
    public List<JSONObject> rankList;
    public List<JSONObject> exhibitionList;
}
#endregion
