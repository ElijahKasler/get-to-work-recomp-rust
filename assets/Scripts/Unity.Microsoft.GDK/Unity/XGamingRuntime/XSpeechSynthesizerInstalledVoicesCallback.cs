using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime;

public delegate bool XSpeechSynthesizerInstalledVoicesCallback([In] ref XSpeechSynthesizerVoiceInformation information, IntPtr context);
