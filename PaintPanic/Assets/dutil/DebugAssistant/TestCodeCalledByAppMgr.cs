

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

			Mgr.Debug.TestLog?.SetText("IsTouch", di.Touch.GetTouch(0));
			Mgr.Debug.TestLog?.SetText("TouchPos", di.Touch.GetTouchPosition(0));
			Mgr.Debug.TestLog?.SetText("LastTouchPos", di.Touch.LastTouchedPosition);
			Mgr.Debug.TestLog?.SetText("LastTouchPosP", di.Touch.LastTouchedPositionP);

		}

	}

}

