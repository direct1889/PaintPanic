

namespace du.Test {


	public interface ITestCode {

		void Test();

	}


	public class TestCodeCalledAtAppBoot : ITestCode {

		public void Test() {

			di.Touch.GetTouch(5);

		}

	}

}

