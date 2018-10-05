using UnityEngine;

namespace du.Test {

	public class DebugAssistant : App.SingletonMonoBehaviour<DebugAssistant> {

		#region field

		public TestLogger TestLog { private set; get; } = null;
		ITestCode m_test = null;

		#endregion


		#region mono

		private void Awake() {
			Instance.m_test = new TestCodeCalledByAppMgr();
			Mgr.RegisterMgr(Instance);
			Instance.m_test.OnBoot();
		}

		private void Update() {
			m_test.OnUpdate();
		}

		#endregion


		#region public

		public void SetTestLog(TestLogger log) {
			TestLog = log;
		}

		#endregion

	}

}
