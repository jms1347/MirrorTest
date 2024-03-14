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
#region ���� ������ ����
[System.Serializable]
public class FR_Connect
{
    public string userId;
    public int contentId;
    public DateTime logDate;
}
#endregion
#region ����Ʈ ���� �� ���
[System.Serializable]
public class FR_Point_Log
{
    public string userId;
    public string contentArea;
    public int usePoint;

}
#endregion
#region ī�װ� ����
[System.Serializable]
public class FR_Category
{
    public string categoryId;
    public string categoryName;
    public string categoryType;     //1 - ������, 2-360VR, 3-����
    public int categoryEA;          //�Է°����� ���� ��
}
#endregion
#region ����ǰ ����
[System.Serializable]
public class FR_Content
{
    public int contentId;
    public string categoryId;
    public int contentOrder;
    public string contentFile;
    public bool isView; // 1 : ǥ��, 0 : ǥ������ ����
    public DateTime contentRegistrationDate;
}
#endregion
#region ȸ������
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
    public Identity identity;   //���� : T , �л� : S, ������(�б��Ҽ��̾ƴ�) : N
    public int point;
    public int rank;
    public bool isAdmin;    //���� ���� ����
}
#endregion

#region ��ŷ
public class FR_RankData
{
    public int rank;
    public string userId;
    public int point;
}
#endregion

#region ī�װ� ������
public class FR_CategoryData
{
    public string contentId;
    public string categoryId;
    public int ord;
    public string contentFile;
}
#endregion

#region �̼� ���
[System.Serializable]
public class FR_Mission_Result
{
    public string userId;
    public string missionId;
    public int missionType; // 1 : �����û, 2: 360��VR, 3:����
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
