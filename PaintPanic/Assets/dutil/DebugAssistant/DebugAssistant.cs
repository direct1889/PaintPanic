using UnityEngine;

namespace du.Test {

	public class DebugAssistant : App.SingletonMonoBehaviour<DebugAssistant> {

		#region field

		[SerializeField] TestLogger m_testLog = null;

		public TestLogger TestLog { get { return m_testLog; } }
		Test.ITestCode m_test = null;

		#endregion


		#region mono
		private void Awake() {
			Instance.m_test = new Test.TestCodeCalledByAppMgr();
			Mgr.RegisterMgr(Instance);
			Instance.m_test.OnBoot();
		}

		private void Update() {
			m_test.OnUpdate();
		}

		#endregion


		#region private
		#endregion

	}

}
