// using System.Collections.Generic;
using UnityEngine;


namespace du.Sys {

	public class AppManager : MonoBehaviour {

		#region singleton

		public static AppManager Instance { get; private set; } = null;

		#endregion


		#region field

		// [SerializeField] List<Initializable> m_initializables = null;

		[SerializeField] bool m_isMute = true;
		[SerializeField] float m_masterVolume = 0.01f;
		[SerializeField] bool m_isDebugMode = false;
		[SerializeField] TestLogger m_testLog = null;

		public TestLogger TestLog { get { return m_testLog; }}
		Test.ITestCode m_test = null;

		#endregion


		#region mono

		private void Awake() {

			if (Instance != null) {
				return;
			}

			Instance = this;
			DontDestroyOnLoad(gameObject);

			Boot();

		}

		private void Update() {
			if (m_isDebugMode) {
				m_test.OnUpdate();
			}
		}

		#endregion


		#region private

		private void Boot() {

			Debug.Log("Boot Apprication");

			Cursor.visible = false;

			// dev.Debug.Initialize(m_isDebugMode, m_isDebugEntry);

			// DG.Tweening.DOTween.Init();

			// for (int i = 0; i < m_initializables.Count; ++i) {
			// 	m_initializables[i].Initialize();
			// }
			/*
			du.Input.InputManager.Initialize();
			du.Input.Id.IdConverter.SetPlayer2GamePad(
				dutil.Input.Id.GamePad._1P,
				dutil.Input.Id.GamePad._2P,
				dutil.Input.Id.GamePad._3P,
				dutil.Input.Id.GamePad._4P
				);
			*/

			// UI.UIAsset.Initialize();

			// utility.sound.SoundManager.Init();
			// utility.sound.SoundManager.BGM
			// .MasterVolumeSet(m_isMute ? 0f : m_masterVolume);

			// GlobalStore.IsMute = m_isMute;

			if (m_isDebugMode) {
				Instance.m_test = new Test.TestCodeCalledByAppMgr();
				Instance.m_test.OnBoot();
			}
			else {
				Instance.m_testLog.gameObject.SetActive(false);
			}


		}

		#endregion

	}

}
