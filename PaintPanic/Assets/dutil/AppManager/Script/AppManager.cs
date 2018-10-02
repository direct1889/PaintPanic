using System.Collections.Generic;
using UnityEngine;
using System;


namespace du.App {

	public class AppManager : MonoBehaviour {

		#region singleton

		public static AppManager Instance { get; private set; } = null;

		#endregion


		#region field

		// [SerializeField] List<Initializable> m_initializables = null;

		[SerializeField] bool m_isMute = true;
		[SerializeField] float m_masterVolume = 0.01f;
		[SerializeField] bool m_isDebugMode = false;

		IList<Action> m_fixedUpdateActs = null;

		#endregion


		#region mono

		private void Awake() {

			if (Instance != null) {
				return;
			}

			Instance = this;
			Mgr.RegisterMgr(Instance);
			DontDestroyOnLoad(gameObject);

			Boot();

		}

		private void FixedUpdate() {
			for (int i = 0; i < m_fixedUpdateActs.Count; ++i) {
				m_fixedUpdateActs[i]();
			}
		}

		#endregion


		#region public

		public void RegisterFixedUpdatedAction(Action act) {
			m_fixedUpdateActs.Add(act);
		}

		#endregion


		#region private

		private void Boot() {

			Debug.Log("Boot Apprication");

			m_fixedUpdateActs = new List<Action>();
			Test.DebugAssistant.Instance.gameObject.SetActive(m_isDebugMode);
			di.RxTouchInput.Initialize();

			Cursor.visible = false;

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



		}

		#endregion

	}

}
