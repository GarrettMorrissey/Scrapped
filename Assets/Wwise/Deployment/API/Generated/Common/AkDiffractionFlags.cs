#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public enum AkDiffractionFlags {
  DiffractionFlags_UseBuiltInParam = 1 << 0,
  DiffractionFlags_UseObstruction = 1 << 1,
  DiffractionFlags_CalcEmitterVirtualPosition = 1 << 3,
  DefaultDiffractionFlags = DiffractionFlags_UseBuiltInParam|DiffractionFlags_UseObstruction|DiffractionFlags_CalcEmitterVirtualPosition
}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.