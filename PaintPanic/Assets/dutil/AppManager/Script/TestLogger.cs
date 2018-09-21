﻿using System.Collections.Generic;
using UnityEngine;
using UGUI = UnityEngine.UI;


namespace du.Sys {

	public class TestLogger : MonoBehaviour {

		#region field

		[SerializeField] GameObject m_logBoxPref = null;
		[SerializeField] List<string> m_logsLabel = null;

		IDictionary<string, dui.TextBox> m_logs = new Dictionary<string, dui.TextBox>();

		#endregion


		#region mono

		private void Start() {

			for (int i = 0; i < m_logsLabel.Count; ++i) {
				dui.TextBox logBox = Instantiate(m_logBoxPref).GetComponent<dui.TextBox>();
				logBox.transform.parent = transform;
				logBox.locate(i);
				m_logs.Add(m_logsLabel[i], logBox);
			}

		}

		#endregion


		#region public

		public void SetText(string key, string value) {

			if (m_logs.ContainsKey(key)){
				m_logs[key].SetText(value);
			}
			else {
				Debug.LogError("Entered key \"" + key + "\" does not exist.");
			}

		}

		#endregion


	}

}
