using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;

namespace System.Windows.Forms;

public sealed class Application
{
	internal class MWFThread
	{
		private ApplicationContext context;

		private bool messageloop_started;

		private bool handling_exception;

		private int thread_id;

		private static readonly Hashtable threads = new Hashtable();

		public ApplicationContext Context
		{
			get
			{
				return context;
			}
			set
			{
				context = value;
			}
		}

		public bool MessageLoop
		{
			get
			{
				return messageloop_started;
			}
			set
			{
				messageloop_started = value;
			}
		}

		public bool HandlingException
		{
			get
			{
				return handling_exception;
			}
			set
			{
				handling_exception = value;
			}
		}

		public static int LoopCount
		{
			get
			{
				lock (threads)
				{
					int num = 0;
					foreach (MWFThread value in threads.Values)
					{
						if (value.messageloop_started)
						{
							num++;
						}
					}
					return num;
				}
			}
		}

		public static MWFThread Current
		{
			get
			{
				MWFThread mWFThread = null;
				lock (threads)
				{
					mWFThread = (MWFThread)threads[Thread.CurrentThread.GetHashCode()];
					if (mWFThread == null)
					{
						mWFThread = new MWFThread();
						mWFThread.thread_id = Thread.CurrentThread.GetHashCode();
						threads[mWFThread.thread_id] = mWFThread;
					}
				}
				return mWFThread;
			}
		}

		private MWFThread()
		{
		}

		public void Exit()
		{
			if (context != null)
			{
				context.ExitThread();
			}
			context = null;
			if (ThreadExit != null)
			{
				ThreadExit(null, EventArgs.Empty);
			}
			if (LoopCount == 0 && ApplicationExit != null)
			{
				ApplicationExit(null, EventArgs.Empty);
			}
			((MWFThread)threads[thread_id]).MessageLoop = false;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public delegate bool MessageLoopCallback();

	private static bool browser_embedded;

	private static InputLanguage input_language;

	private static string safe_caption_format;

	private static readonly ArrayList message_filters;

	private static readonly FormCollection forms;

	private static bool use_wait_cursor;

	private static ToolStrip keyboard_capture;

	private static VisualStyleState visual_style_state;

	private static bool visual_styles_enabled;

	internal static bool use_compatible_text_rendering;

	public static bool AllowQuit => !browser_embedded;

	public static string CommonAppDataPath => CreateDataPath(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

	public static RegistryKey CommonAppDataRegistry
	{
		get
		{
			string subkey = $"Software\\{CompanyName}\\{ProductName}\\{ProductVersion}";
			return Registry.LocalMachine.CreateSubKey(subkey);
		}
	}

	public static string CompanyName
	{
		get
		{
			string text = string.Empty;
			Assembly assembly = Assembly.GetEntryAssembly();
			if (assembly == null)
			{
				assembly = Assembly.GetCallingAssembly();
			}
			AssemblyCompanyAttribute[] array = (AssemblyCompanyAttribute[])assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: true);
			if (array != null && array.Length != 0)
			{
				text = array[0].Company;
			}
			if ((text == null || text.Length == 0) && assembly.EntryPoint != null)
			{
				text = assembly.EntryPoint.DeclaringType.Namespace;
				if (text != null)
				{
					int num = text.IndexOf('.');
					if (num >= 0)
					{
						text = text.Substring(0, num);
					}
				}
			}
			if ((text == null || text.Length == 0) && assembly.EntryPoint != null)
			{
				text = assembly.EntryPoint.DeclaringType.FullName;
			}
			return text;
		}
	}

	public static CultureInfo CurrentCulture
	{
		get
		{
			return Thread.CurrentThread.CurrentUICulture;
		}
		set
		{
			Thread.CurrentThread.CurrentUICulture = value;
		}
	}

	public static InputLanguage CurrentInputLanguage
	{
		get
		{
			return input_language;
		}
		set
		{
			input_language = value;
		}
	}

	public static string ExecutablePath => Path.GetFullPath(Environment.GetCommandLineArgs()[0]);

	public static string LocalUserAppDataPath => CreateDataPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

	public static bool MessageLoop => MWFThread.Current.MessageLoop;

	public static string ProductName
	{
		get
		{
			string text = string.Empty;
			Assembly assembly = Assembly.GetEntryAssembly();
			if (assembly == null)
			{
				assembly = Assembly.GetCallingAssembly();
			}
			AssemblyProductAttribute[] array = (AssemblyProductAttribute[])assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: true);
			if (array != null && array.Length != 0)
			{
				text = array[0].Product;
			}
			if ((text == null || text.Length == 0) && assembly.EntryPoint != null)
			{
				text = assembly.EntryPoint.DeclaringType.Namespace;
				if (text != null)
				{
					int num = text.LastIndexOf('.');
					if (num >= 0 && num < text.Length - 1)
					{
						text = text.Substring(num + 1);
					}
				}
				if (text == null || text.Length == 0)
				{
					text = assembly.EntryPoint.DeclaringType.FullName;
				}
			}
			return text;
		}
	}

	public static string ProductVersion
	{
		get
		{
			string text = string.Empty;
			Assembly assembly = Assembly.GetEntryAssembly();
			if (assembly == null)
			{
				assembly = Assembly.GetCallingAssembly();
			}
			if (Attribute.GetCustomAttribute(assembly, typeof(AssemblyInformationalVersionAttribute)) is AssemblyInformationalVersionAttribute assemblyInformationalVersionAttribute)
			{
				text = assemblyInformationalVersionAttribute.InformationalVersion;
			}
			if ((text == null || text.Length == 0) && Attribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute)) is AssemblyFileVersionAttribute assemblyFileVersionAttribute)
			{
				text = assemblyFileVersionAttribute.Version;
			}
			if (text == null || text.Length == 0)
			{
				text = assembly.GetName().Version.ToString();
			}
			return text;
		}
	}

	public static string SafeTopLevelCaptionFormat
	{
		get
		{
			return safe_caption_format;
		}
		set
		{
			safe_caption_format = value;
		}
	}

	public static string StartupPath => Path.GetDirectoryName(ExecutablePath);

	public static string UserAppDataPath => CreateDataPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

	public static RegistryKey UserAppDataRegistry
	{
		get
		{
			string subkey = $"Software\\{CompanyName}\\{ProductName}\\{ProductVersion}";
			return Registry.CurrentUser.CreateSubKey(subkey);
		}
	}

	public static bool UseWaitCursor
	{
		get
		{
			return use_wait_cursor;
		}
		set
		{
			use_wait_cursor = value;
			if (!use_wait_cursor)
			{
				return;
			}
			foreach (Form openForm in OpenForms)
			{
				openForm.Cursor = Cursors.WaitCursor;
			}
		}
	}

	public static bool RenderWithVisualStyles
	{
		get
		{
			if (VisualStyleInformation.IsSupportedByOS)
			{
				if (!VisualStyleInformation.IsEnabledByUser)
				{
					return false;
				}
				if (!XplatUI.ThemesEnabled)
				{
					return false;
				}
				if (VisualStyleState == VisualStyleState.ClientAndNonClientAreasEnabled)
				{
					return true;
				}
				if (VisualStyleState == VisualStyleState.ClientAreaEnabled)
				{
					return true;
				}
			}
			return false;
		}
	}

	public static VisualStyleState VisualStyleState
	{
		get
		{
			return visual_style_state;
		}
		set
		{
			visual_style_state = value;
		}
	}

	public static FormCollection OpenForms => forms;

	internal static ToolStrip KeyboardCapture
	{
		get
		{
			return keyboard_capture;
		}
		set
		{
			keyboard_capture = value;
		}
	}

	internal static bool VisualStylesEnabled => visual_styles_enabled;

	public static event EventHandler ApplicationExit;

	public static event EventHandler Idle
	{
		add
		{
			XplatUI.Idle += value;
		}
		remove
		{
			XplatUI.Idle -= value;
		}
	}

	public static event EventHandler ThreadExit;

	public static event ThreadExceptionEventHandler ThreadException;

	internal static event EventHandler FormAdded;

	internal static event EventHandler PreRun;

	[System.MonoTODO]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static event EventHandler EnterThreadModal;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[System.MonoTODO]
	public static event EventHandler LeaveThreadModal;

	private Application()
	{
		browser_embedded = false;
	}

	static Application()
	{
		input_language = InputLanguage.CurrentInputLanguage;
		safe_caption_format = "{1} - {0} - {2}";
		message_filters = new ArrayList();
		forms = new FormCollection();
		visual_style_state = VisualStyleState.ClientAndNonClientAreasEnabled;
		use_compatible_text_rendering = true;
		InitializeUIAutomation();
	}

	private static void InitializeUIAutomation()
	{
		Assembly assembly = null;
		try
		{
			assembly = Assembly.Load("UIAutomationWinforms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4ceacb585d99812");
		}
		catch
		{
		}
		if (assembly == null)
		{
			return;
		}
		try
		{
			Type type = assembly.GetType("Mono.UIAutomation.Winforms.Global", throwOnError: false);
			if (type != null)
			{
				MethodInfo method = type.GetMethod("Initialize", BindingFlags.Static | BindingFlags.Public);
				if (method != null)
				{
					method.Invoke(null, new object[0]);
					return;
				}
				throw new Exception(string.Format("Method {0} not found in type {1}.", "Initialize", "Mono.UIAutomation.Winforms.Global"));
			}
			throw new Exception(string.Format("Type {0} not found in assembly {1}.", "Mono.UIAutomation.Winforms.Global", "UIAutomationWinforms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4ceacb585d99812"));
		}
		catch (Exception ex)
		{
			Console.Error.WriteLine("Error setting up UIA: " + ex);
		}
	}

	internal static void CloseForms(Thread thread)
	{
		ArrayList arrayList = new ArrayList();
		lock (forms)
		{
			foreach (Form form in forms)
			{
				if (thread == null || thread == form.creator_thread)
				{
					arrayList.Add(form);
				}
			}
			foreach (Form item in arrayList)
			{
				item.Dispose();
			}
		}
	}

	public static void AddMessageFilter(IMessageFilter value)
	{
		lock (message_filters)
		{
			message_filters.Add(value);
		}
	}

	internal static void AddKeyFilter(IKeyFilter value)
	{
		XplatUI.AddKeyFilter(value);
	}

	public static void DoEvents()
	{
		XplatUI.DoEvents();
	}

	public static void EnableVisualStyles()
	{
		visual_styles_enabled = true;
		XplatUI.EnableThemes();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static bool FilterMessage(ref Message message)
	{
		lock (message_filters)
		{
			for (int i = 0; i < message_filters.Count; i++)
			{
				if (((IMessageFilter)message_filters[i]).PreFilterMessage(ref message))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void SetCompatibleTextRenderingDefault(bool defaultValue)
	{
		use_compatible_text_rendering = defaultValue;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[System.MonoNotSupported("Only applies when Winforms is being hosted by an unmanaged app.")]
	public static void RegisterMessageLoop(MessageLoopCallback callback)
	{
	}

	[System.MonoNotSupported("Empty stub.")]
	public static bool SetSuspendState(PowerState state, bool force, bool disableWakeEvent)
	{
		return false;
	}

	[System.MonoNotSupported("Empty stub.")]
	public static void SetUnhandledExceptionMode(UnhandledExceptionMode mode)
	{
	}

	[System.MonoNotSupported("Empty stub.")]
	public static void SetUnhandledExceptionMode(UnhandledExceptionMode mode, bool threadScope)
	{
	}

	[System.MonoNotSupported("Only applies when Winforms is being hosted by an unmanaged app.")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static void UnregisterMessageLoop()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static void RaiseIdle(EventArgs e)
	{
		XplatUI.RaiseIdle(e);
	}

	public static void Restart()
	{
		if (Assembly.GetEntryAssembly() == null)
		{
			throw new NotSupportedException("The method 'Restart' is not supported by this application type.");
		}
		string mono = System.MonoToolsLocator.Mono;
		StringBuilder stringBuilder = new StringBuilder();
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			stringBuilder.Append($"\"{commandLineArgs[i]}\" ");
		}
		string text = stringBuilder.ToString();
		ProcessStartInfo startInfo = Process.GetCurrentProcess().StartInfo;
		if (mono == null)
		{
			startInfo.FileName = commandLineArgs[0];
			startInfo.Arguments = text.Remove(0, commandLineArgs[0].Length + 3);
		}
		else
		{
			startInfo.Arguments = text;
			startInfo.FileName = mono;
		}
		startInfo.WorkingDirectory = Environment.CurrentDirectory;
		Exit();
		Process.Start(startInfo);
	}

	public static void Exit()
	{
		Exit(new CancelEventArgs());
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static void Exit(CancelEventArgs e)
	{
		lock (forms)
		{
			foreach (Form item in new ArrayList(forms))
			{
				e.Cancel = item.FireClosingEvents(CloseReason.ApplicationExitCall, cancel: false);
				if (e.Cancel)
				{
					return;
				}
				item.suppress_closing_events = true;
				item.Close();
				item.Dispose();
			}
		}
		XplatUI.PostQuitMessage(0);
	}

	public static void ExitThread()
	{
		CloseForms(Thread.CurrentThread);
		XplatUI.PostQuitMessage(0);
	}

	public static ApartmentState OleRequired()
	{
		return ApartmentState.Unknown;
	}

	public static void OnThreadException(Exception t)
	{
		if (MWFThread.Current.HandlingException)
		{
			Console.WriteLine(t);
			Environment.Exit(1);
		}
		try
		{
			MWFThread.Current.HandlingException = true;
			if (ThreadException != null)
			{
				ThreadException(null, new ThreadExceptionEventArgs(t));
				return;
			}
			if (SystemInformation.UserInteractive)
			{
				new ThreadExceptionDialog(t).ShowDialog();
				return;
			}
			Console.WriteLine(t.ToString());
			Exit();
		}
		finally
		{
			MWFThread.Current.HandlingException = false;
		}
	}

	public static void RemoveMessageFilter(IMessageFilter value)
	{
		lock (message_filters)
		{
			message_filters.Remove(value);
		}
	}

	public static void Run()
	{
		Run(new ApplicationContext());
	}

	public static void Run(Form mainForm)
	{
		Run(new ApplicationContext(mainForm));
	}

	internal static void FirePreRun()
	{
		PreRun?.Invoke(null, EventArgs.Empty);
	}

	public static void Run(ApplicationContext context)
	{
		if (SynchronizationContext.Current == null)
		{
			SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
		}
		RunLoop(Modal: false, context);
		if (SynchronizationContext.Current is WindowsFormsSynchronizationContext)
		{
			WindowsFormsSynchronizationContext.Uninstall();
		}
	}

	private static void DisableFormsForModalLoop(Queue toplevels, ApplicationContext context)
	{
		lock (forms)
		{
			IEnumerator enumerator = forms.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Form form = (Form)enumerator.Current;
				if (form == context.MainForm)
				{
					continue;
				}
				Control control = form;
				bool flag = false;
				do
				{
					if (control.Parent == context.MainForm)
					{
						flag = true;
						break;
					}
					control = control.Parent;
				}
				while (control != null);
				if (!flag && form.IsHandleCreated && XplatUI.IsEnabled(form.Handle))
				{
					XplatUI.EnableWindow(form.Handle, Enable: false);
					toplevels.Enqueue(form);
				}
			}
		}
	}

	private static void EnableFormsForModalLoop(Queue toplevels, ApplicationContext context)
	{
		while (toplevels.Count > 0)
		{
			Form form = (Form)toplevels.Dequeue();
			if (form.IsHandleCreated)
			{
				XplatUI.EnableWindow(form.window.Handle, Enable: true);
				context.MainForm = form;
			}
		}
	}

	internal static void RunLoop(bool Modal, ApplicationContext context)
	{
		MWFThread current = MWFThread.Current;
		MSG msg = default;
		if (context == null)
		{
			context = new ApplicationContext();
		}
		ApplicationContext context2 = current.Context;
		current.Context = context;
		if (context.MainForm != null)
		{
			context.MainForm.is_modal = Modal;
			context.MainForm.context = context;
			context.MainForm.closing = false;
			context.MainForm.Visible = true;
			if (context.MainForm != null)
			{
				context.MainForm.Activate();
			}
		}
		Queue toplevels;
		if (Modal)
		{
			toplevels = new Queue();
			DisableFormsForModalLoop(toplevels, context);
			if (context.MainForm != null)
			{
				XplatUI.EnableWindow(context.MainForm.Handle, Enable: true);
				XplatUI.SetModal(context.MainForm.Handle, Modal: true);
			}
		}
		else
		{
			toplevels = null;
		}
		object queue_id = XplatUI.StartLoop(Thread.CurrentThread);
		current.MessageLoop = true;
		bool flag = false;
		while (!flag && XplatUI.GetMessage(queue_id, ref msg, IntPtr.Zero, 0, 0))
		{
			Message message = Message.Create(msg.hwnd, (int)msg.message, msg.wParam, msg.lParam);
			if (FilterMessage(ref message))
			{
				continue;
			}
			Msg message2 = msg.message;
			if (message2 <= Msg.WM_SYSCHAR)
			{
				if (message2 == Msg.WM_QUIT)
				{
					flag = true;
					goto IL_0307;
				}
				if ((uint)(message2 - 256) <= 2u || (uint)(message2 - 260) <= 2u)
				{
					Control control = Control.FromHandle(msg.hwnd);
					if (keyboard_capture != null)
					{
						if (message.Msg == 260 && message.WParam.ToInt32() == 18)
						{
							keyboard_capture.GetTopLevelToolStrip().Dismiss(ToolStripDropDownCloseReason.Keyboard);
							continue;
						}
						message.HWnd = keyboard_capture.Handle;
						PreProcessControlState preProcessControlState = keyboard_capture.PreProcessControlMessageInternal(ref message);
						if (preProcessControlState == PreProcessControlState.MessageProcessed)
						{
							continue;
						}
						if ((uint)(preProcessControlState - 1) <= 1u)
						{
							if ((message.Msg != 256 && message.Msg != 258) || keyboard_capture.ProcessControlMnemonic((char)(int)message.WParam) || control == null || !ControlOnToolStrip(control))
							{
								continue;
							}
							message.HWnd = msg.hwnd;
						}
					}
					if ((control == null || control.PreProcessControlMessageInternal(ref message) == PreProcessControlState.MessageProcessed) && control != null)
					{
						goto IL_0307;
					}
				}
			}
			else if ((message2 == Msg.WM_LBUTTONDOWN || message2 == Msg.WM_RBUTTONDOWN || message2 == Msg.WM_MBUTTONDOWN) && keyboard_capture != null)
			{
				Control control2 = Control.FromHandle(msg.hwnd);
				if (control2 == null)
				{
					ToolStripManager.FireAppClicked();
				}
				else if (!Control.IsChild(keyboard_capture.Handle, msg.hwnd))
				{
					Point p = control2.PointToScreen(new Point((short)(message.LParam.ToInt32() & 0xFFFF), (short)(message.LParam.ToInt32() >> 16)));
					while (keyboard_capture != null && !keyboard_capture.ClientRectangle.Contains(keyboard_capture.PointToClient(p)))
					{
						keyboard_capture.Dismiss();
					}
				}
			}
			XplatUI.TranslateMessage(ref msg);
			XplatUI.DispatchMessage(ref msg);
			goto IL_0307;
			IL_0307:
			if ((context.MainForm == null || context.MainForm.IsHandleCreated) && context.MainForm != null && (context.MainForm.closing || (Modal && !context.MainForm.Visible)))
			{
				if (Modal)
				{
					break;
				}
				XplatUI.PostQuitMessage(0);
			}
		}
		current.MessageLoop = false;
		XplatUI.EndLoop(Thread.CurrentThread);
		if (Modal)
		{
			Form mainForm = context.MainForm;
			context.MainForm = null;
			EnableFormsForModalLoop(toplevels, context);
			if (mainForm != null && mainForm.IsHandleCreated)
			{
				XplatUI.SetModal(mainForm.Handle, Modal: false);
			}
			mainForm.RaiseCloseEvents(last_check: true, cancel: false);
			mainForm.is_modal = false;
		}
		if (context.MainForm != null)
		{
			context.MainForm.context = null;
			context.MainForm = null;
		}
		current.Context = context2;
		if (!Modal)
		{
			current.Exit();
		}
	}

	internal static void AddForm(Form f)
	{
		lock (forms)
		{
			forms.Add(f);
		}
		if (FormAdded != null)
		{
			FormAdded(f, null);
		}
	}

	internal static void RemoveForm(Form f)
	{
		lock (forms)
		{
			forms.Remove(f);
		}
	}

	private static bool ControlOnToolStrip(Control c)
	{
		for (Control parent = c.Parent; parent != null; parent = parent.Parent)
		{
			if (parent is ToolStrip)
			{
				return true;
			}
		}
		return false;
	}

	private static string CreateDataPath(string basePath)
	{
		string path = Path.Combine(basePath, CompanyName);
		path = Path.Combine(path, ProductName);
		path = Path.Combine(path, ProductVersion);
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		return path;
	}
}
