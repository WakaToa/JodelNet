//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: checkin.proto
namespace JodelNet.Verification.Proto
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckinRequest")]
  public partial class CheckinRequest : global::ProtoBuf.IExtensible
  {
    public CheckinRequest() {}
    
    private string _imei = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"imei", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string imei
    {
      get { return _imei; }
      set { _imei = value; }
    }
    private long _androidId = default(long);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"androidId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long androidId
    {
      get { return _androidId; }
      set { _androidId = value; }
    }
    private string _digest = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"digest", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string digest
    {
      get { return _digest; }
      set { _digest = value; }
    }
    private CheckinRequest.Checkin _checkin;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"checkin", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public CheckinRequest.Checkin checkin
    {
      get { return _checkin; }
      set { _checkin = value; }
    }
    private string _desiredBuild = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"desiredBuild", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string desiredBuild
    {
      get { return _desiredBuild; }
      set { _desiredBuild = value; }
    }
    private string _locale = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"locale", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string locale
    {
      get { return _locale; }
      set { _locale = value; }
    }
    private long _loggingId = default(long);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"loggingId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long loggingId
    {
      get { return _loggingId; }
      set { _loggingId = value; }
    }
    private string _marketCheckin = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"marketCheckin", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string marketCheckin
    {
      get { return _marketCheckin; }
      set { _marketCheckin = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _macAddress = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(9, Name=@"macAddress", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> macAddress
    {
      get { return _macAddress; }
    }
  
    private string _meid = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"meid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string meid
    {
      get { return _meid; }
      set { _meid = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _accountCookie = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(11, Name=@"accountCookie", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> accountCookie
    {
      get { return _accountCookie; }
    }
  
    private string _timeZone = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"timeZone", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string timeZone
    {
      get { return _timeZone; }
      set { _timeZone = value; }
    }
    private ulong _securityToken = default(ulong);
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"securityToken", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong securityToken
    {
      get { return _securityToken; }
      set { _securityToken = value; }
    }
    private int _version = default(int);
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"version", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int version
    {
      get { return _version; }
      set { _version = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _otaCert = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(15, Name=@"otaCert", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> otaCert
    {
      get { return _otaCert; }
    }
  
    private string _serial = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"serial", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string serial
    {
      get { return _serial; }
      set { _serial = value; }
    }
    private string _esn = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"esn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string esn
    {
      get { return _esn; }
      set { _esn = value; }
    }
    private CheckinRequest.DeviceConfig _deviceConfiguration = null;
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"deviceConfiguration", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public CheckinRequest.DeviceConfig deviceConfiguration
    {
      get { return _deviceConfiguration; }
      set { _deviceConfiguration = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _macAddressType = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(19, Name=@"macAddressType", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> macAddressType
    {
      get { return _macAddressType; }
    }
  
    private int _fragment;
    [global::ProtoBuf.ProtoMember(20, IsRequired = true, Name=@"fragment", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int fragment
    {
      get { return _fragment; }
      set { _fragment = value; }
    }
    private string _userName = "";
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"userName", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string userName
    {
      get { return _userName; }
      set { _userName = value; }
    }
    private int _userSerialNumber = default(int);
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"userSerialNumber", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int userSerialNumber
    {
      get { return _userSerialNumber; }
      set { _userSerialNumber = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Checkin")]
  public partial class Checkin : global::ProtoBuf.IExtensible
  {
    public Checkin() {}
    
    private CheckinRequest.Checkin.Build _build;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"build", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public CheckinRequest.Checkin.Build build
    {
      get { return _build; }
      set { _build = value; }
    }
    private long _lastCheckinMs = default(long);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"lastCheckinMs", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long lastCheckinMs
    {
      get { return _lastCheckinMs; }
      set { _lastCheckinMs = value; }
    }
    private readonly global::System.Collections.Generic.List<CheckinRequest.Checkin.Event> _event = new global::System.Collections.Generic.List<CheckinRequest.Checkin.Event>();
    [global::ProtoBuf.ProtoMember(3, Name=@"event", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CheckinRequest.Checkin.Event> @event
    {
      get { return _event; }
    }
  
    private readonly global::System.Collections.Generic.List<CheckinRequest.Checkin.Statistic> _stat = new global::System.Collections.Generic.List<CheckinRequest.Checkin.Statistic>();
    [global::ProtoBuf.ProtoMember(4, Name=@"stat", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CheckinRequest.Checkin.Statistic> stat
    {
      get { return _stat; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _requestedGroup = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(5, Name=@"requestedGroup", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> requestedGroup
    {
      get { return _requestedGroup; }
    }
  
    private string _cellOperator = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"cellOperator", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cellOperator
    {
      get { return _cellOperator; }
      set { _cellOperator = value; }
    }
    private string _simOperator = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"simOperator", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string simOperator
    {
      get { return _simOperator; }
      set { _simOperator = value; }
    }
    private string _roaming = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"roaming", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string roaming
    {
      get { return _roaming; }
      set { _roaming = value; }
    }
    private int _userNumber = default(int);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"userNumber", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int userNumber
    {
      get { return _userNumber; }
      set { _userNumber = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Build")]
  public partial class Build : global::ProtoBuf.IExtensible
  {
    public Build() {}
    
    private string _fingerprint = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"fingerprint", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fingerprint
    {
      get { return _fingerprint; }
      set { _fingerprint = value; }
    }
    private string _hardware = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"hardware", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hardware
    {
      get { return _hardware; }
      set { _hardware = value; }
    }
    private string _brand = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"brand", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string brand
    {
      get { return _brand; }
      set { _brand = value; }
    }
    private string _radio = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"radio", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string radio
    {
      get { return _radio; }
      set { _radio = value; }
    }
    private string _bootloader = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"bootloader", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bootloader
    {
      get { return _bootloader; }
      set { _bootloader = value; }
    }
    private string _clientId = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"clientId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clientId
    {
      get { return _clientId; }
      set { _clientId = value; }
    }
    private long _time = default(long);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long time
    {
      get { return _time; }
      set { _time = value; }
    }
    private int _packageVersionCode = default(int);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"packageVersionCode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int packageVersionCode
    {
      get { return _packageVersionCode; }
      set { _packageVersionCode = value; }
    }
    private string _device = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"device", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device
    {
      get { return _device; }
      set { _device = value; }
    }
    private int _sdkVersion = default(int);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"sdkVersion", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int sdkVersion
    {
      get { return _sdkVersion; }
      set { _sdkVersion = value; }
    }
    private string _model = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"model", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string model
    {
      get { return _model; }
      set { _model = value; }
    }
    private string _manufacturer = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"manufacturer", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string manufacturer
    {
      get { return _manufacturer; }
      set { _manufacturer = value; }
    }
    private string _product = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"product", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string product
    {
      get { return _product; }
      set { _product = value; }
    }
    private bool _otaInstalled = default(bool);
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"otaInstalled", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool otaInstalled
    {
      get { return _otaInstalled; }
      set { _otaInstalled = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Event")]
  public partial class Event : global::ProtoBuf.IExtensible
  {
    public Event() {}
    
    private string _tag = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"tag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag
    {
      get { return _tag; }
      set { _tag = value; }
    }
    private string _value = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string value
    {
      get { return _value; }
      set { _value = value; }
    }
    private long _timeMs = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"timeMs", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long timeMs
    {
      get { return _timeMs; }
      set { _timeMs = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Statistic")]
  public partial class Statistic : global::ProtoBuf.IExtensible
  {
    public Statistic() {}
    
    private string _tag;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"tag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string tag
    {
      get { return _tag; }
      set { _tag = value; }
    }
    private int _count = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int count
    {
      get { return _count; }
      set { _count = value; }
    }
    private float _sum = default(float);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"sum", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float sum
    {
      get { return _sum; }
      set { _sum = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DeviceConfig")]
  public partial class DeviceConfig : global::ProtoBuf.IExtensible
  {
    public DeviceConfig() {}
    
    private int _touchScreen = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"touchScreen", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int touchScreen
    {
      get { return _touchScreen; }
      set { _touchScreen = value; }
    }
    private int _keyboardType = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"keyboardType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int keyboardType
    {
      get { return _keyboardType; }
      set { _keyboardType = value; }
    }
    private int _navigation = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"navigation", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int navigation
    {
      get { return _navigation; }
      set { _navigation = value; }
    }
    private int _screenLayout = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"screenLayout", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int screenLayout
    {
      get { return _screenLayout; }
      set { _screenLayout = value; }
    }
    private bool _hasHardKeyboard = default(bool);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"hasHardKeyboard", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool hasHardKeyboard
    {
      get { return _hasHardKeyboard; }
      set { _hasHardKeyboard = value; }
    }
    private bool _hasFiveWayNavigation = default(bool);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"hasFiveWayNavigation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool hasFiveWayNavigation
    {
      get { return _hasFiveWayNavigation; }
      set { _hasFiveWayNavigation = value; }
    }
    private int _densityDpi = default(int);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"densityDpi", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int densityDpi
    {
      get { return _densityDpi; }
      set { _densityDpi = value; }
    }
    private int _glEsVersion = default(int);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"glEsVersion", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int glEsVersion
    {
      get { return _glEsVersion; }
      set { _glEsVersion = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _sharedLibrary = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(9, Name=@"sharedLibrary", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> sharedLibrary
    {
      get { return _sharedLibrary; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _availableFeature = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(10, Name=@"availableFeature", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> availableFeature
    {
      get { return _availableFeature; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _nativePlatform = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(11, Name=@"nativePlatform", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> nativePlatform
    {
      get { return _nativePlatform; }
    }
  
    private int _widthPixels = default(int);
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"widthPixels", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int widthPixels
    {
      get { return _widthPixels; }
      set { _widthPixels = value; }
    }
    private int _heightPixels = default(int);
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"heightPixels", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int heightPixels
    {
      get { return _heightPixels; }
      set { _heightPixels = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _locale = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(14, Name=@"locale", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> locale
    {
      get { return _locale; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _glExtension = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(15, Name=@"glExtension", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> glExtension
    {
      get { return _glExtension; }
    }
  
    private int _deviceClass = default(int);
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"deviceClass", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int deviceClass
    {
      get { return _deviceClass; }
      set { _deviceClass = value; }
    }
    private int _maxApkDownloadSizeMb = default(int);
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"maxApkDownloadSizeMb", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int maxApkDownloadSizeMb
    {
      get { return _maxApkDownloadSizeMb; }
      set { _maxApkDownloadSizeMb = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }





  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckinResponse")]
  public partial class CheckinResponse : global::ProtoBuf.IExtensible
  {
    public CheckinResponse() {}
    
    private bool _statsOk = default(bool);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"statsOk", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool statsOk
    {
      get { return _statsOk; }
      set { _statsOk = value; }
    }
    private readonly global::System.Collections.Generic.List<CheckinResponse.Intent> _intent = new global::System.Collections.Generic.List<CheckinResponse.Intent>();
    [global::ProtoBuf.ProtoMember(2, Name=@"intent", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CheckinResponse.Intent> intent
    {
      get { return _intent; }
    }
  
    private long _timeMs = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"timeMs", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long timeMs
    {
      get { return _timeMs; }
      set { _timeMs = value; }
    }
    private string _digest = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"digest", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string digest
    {
      get { return _digest; }
      set { _digest = value; }
    }
    private readonly global::System.Collections.Generic.List<CheckinResponse.GservicesSetting> _setting = new global::System.Collections.Generic.List<CheckinResponse.GservicesSetting>();
    [global::ProtoBuf.ProtoMember(5, Name=@"setting", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CheckinResponse.GservicesSetting> setting
    {
      get { return _setting; }
    }
  
    private bool _marketOk = default(bool);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"marketOk", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool marketOk
    {
      get { return _marketOk; }
      set { _marketOk = value; }
    }
    private ulong _androidId = default(ulong);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"androidId", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong androidId
    {
      get { return _androidId; }
      set { _androidId = value; }
    }
    private ulong _securityToken = default(ulong);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"securityToken", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong securityToken
    {
      get { return _securityToken; }
      set { _securityToken = value; }
    }
    private bool _settingsDiff = default(bool);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"settingsDiff", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool settingsDiff
    {
      get { return _settingsDiff; }
      set { _settingsDiff = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _deleteSetting = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(10, Name=@"deleteSetting", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> deleteSetting
    {
      get { return _deleteSetting; }
    }
  
    private string _versionInfo = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"versionInfo", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string versionInfo
    {
      get { return _versionInfo; }
      set { _versionInfo = value; }
    }
    private string _deviceDataVersionInfo = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"deviceDataVersionInfo", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string deviceDataVersionInfo
    {
      get { return _deviceDataVersionInfo; }
      set { _deviceDataVersionInfo = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Intent")]
  public partial class Intent : global::ProtoBuf.IExtensible
  {
    public Intent() {}
    
    private string _action = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"action", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string action
    {
      get { return _action; }
      set { _action = value; }
    }
    private string _dataUri = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"dataUri", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dataUri
    {
      get { return _dataUri; }
      set { _dataUri = value; }
    }
    private string _mimeType = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"mimeType", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mimeType
    {
      get { return _mimeType; }
      set { _mimeType = value; }
    }
    private string _javaClass = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"javaClass", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string javaClass
    {
      get { return _javaClass; }
      set { _javaClass = value; }
    }
    private readonly global::System.Collections.Generic.List<CheckinResponse.Intent.Extra> _extra = new global::System.Collections.Generic.List<CheckinResponse.Intent.Extra>();
    [global::ProtoBuf.ProtoMember(5, Name=@"extra", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CheckinResponse.Intent.Extra> extra
    {
      get { return _extra; }
    }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Extra")]
  public partial class Extra : global::ProtoBuf.IExtensible
  {
    public Extra() {}
    
    private string _name = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private string _value = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string value
    {
      get { return _value; }
      set { _value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GservicesSetting")]
  public partial class GservicesSetting : global::ProtoBuf.IExtensible
  {
    public GservicesSetting() {}
    
    private byte[] _name = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] name
    {
      get { return _name; }
      set { _name = value; }
    }
    private byte[] _value = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] value
    {
      get { return _value; }
      set { _value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}