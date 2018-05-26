namespace JodelNet.Verification.Proto
{
    //https://github.com/microg/android_packages_apps_GmsCore/blob/93c3cbb31be6c8ffae81c18e551cb00c74aaaaf4/play-services-core/src/main/java/org/microg/gms/gcm/mcs/Constants.java
    public enum MCSToken
    {
        MCS_HEARTBEAT_ACK_TAG = 1,
        MCS_LOGIN_REQUEST_TAG = 2,
        MCS_LOGIN_RESPONSE_TAG = 3,
        MCS_CLOSE_TAG = 4,
        MCS_IQ_STANZA_TAG = 7,
        MCS_DATA_MESSAGE_STANZA_TAG = 8,

        MCS_VERSION_CODE = 41
    }
}
