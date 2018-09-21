

namespace du.Test {


	public interface ITestCode {

		void OnBoot();
		void OnUpdate();

	}


	public class TestCodeCalledByAppMgr : ITestCode {

		public void OnBoot() {

			di.Touch.GetTouch(5);

		}

		public void OnUpdate() {

			Sys.AppManager.Instance.TestLog.SetText("IsTouch", di.Touch.GetTouch(0));
			Sys.AppManager.Instance.TestLog.SetText("TouchPos", di.Touch.GetTouchPosition(0));
			Sys.AppManager.Instance.TestLog.SetText("Hoge", "Hoge");

		}

	}

}

