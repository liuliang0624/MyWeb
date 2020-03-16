using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
///ServiceInfo 的摘要说明
/// </summary>
public class ServiceInfo
{

    #region 私有成员

    private int _ID;
    private string _serviceName;	
    private string _serviceUrl;	
    private string _isDynamic;	
    private string _serviceNailUrl;	
    private string _platForm;
    private string _cateGorp;
    private string _wmsUrl;
    private string _wfsUrl;
    private string _wcsUrl;
    private string _kmlUrl;
    private string _memo;		

    #endregion 

    #region 属性

    public int ID
    {
        set
        {
            this._ID = value;
        }
        get
        {
            return this._ID;
        }
    }
    public string ServiceName
    {
        set
        {
            this._serviceName = value;
        }
        get
        {
            return this._serviceName;
        }
    }
    public string ServiceUrl
    {
        set
        {
            this._serviceUrl = value;
        }
        get
        {
            return this._serviceUrl;
        }
    }
    public string IsDynamic
    {
        set
        {
            this._isDynamic = value;
        }
        get
        {
            return this._isDynamic;
        }
    }
    public string ServiceNailUrl
    {
        set
        {
            this._serviceNailUrl = value;
        }
        get
        {
            return this._serviceNailUrl;
        }
    }
    public string PlatForm
    {
        set
        {
            this._platForm = value;
        }
        get
        {
            return this._platForm;
        }
    }
    public string CateGorp
    {
        set
        {
            this._cateGorp = value;
        }
        get
        {
            return this._cateGorp;
        }
    }
    public string WmsUrl
    {
        set
        {
            this._wmsUrl = value;
        }
        get
        {
            return this._wmsUrl;
        }
    }
    public string Wfsurl
    {
        set
        {
            this._wfsUrl = value;
        }
        get
        {
            return this._wfsUrl;
        }
    }
    public string WcsUrl
    {
        set
        {
            this._wcsUrl = value;
        }
        get
        {
            return this._wcsUrl;
        }
    }
    public string Kmlurl
    {
        set
        {
            this._kmlUrl = value;
        }
        get
        {
            return this._kmlUrl;
        }
    }
    public string Memo
    {
        set
        {
            this._memo = value;
        }
        get
        {
            return this._memo;
        }
    }
    #endregion 属性

    #region 方法


    #endregion
}