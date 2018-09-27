using UnityEngine;


namespace du {

	public static class Mgr {


		#region field

		// static AppManager s_appMgr = null;
		// static Test.DebugAssistant s_debugAssistant = null;

		#endregion


		#region property

		// public static AppManager App { get { return s_appMgr; } }
		// public static Test.DebugAssistant Debug { get { return s_debugAssistant; } }

		public static App.AppManager App { private set; get; }
		public static Test.DebugAssistant Debug { private set; get; }

		#endregion


		#region public

		public static void RegisterMgr(App.AppManager appMgr) { App = appMgr; }
		public static void RegisterMgr(Test.DebugAssistant debugAsst) { Debug = debugAsst; }

		#endregion


	}

}