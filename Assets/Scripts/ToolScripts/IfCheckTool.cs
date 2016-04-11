//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace AssemblyCSharp
{
	public class IfCheckTool : ITool
	{
		public IfCheckTool ()
		{
		}

		#region ITool implementation

		public void Execute (ref ToolExecutionStatus status)
		{
			if (String.IsNullOrEmpty (status.TestString)) {
				status.Status = ToolStatus.NO_STATUS;
				status.NextDirection = ToolOutputDirection.DOWN;
				return;
			}

			status.Status = ToolStatus.NO_STATUS;
			char topChar = status.TestString [0];
			status.TestString = status.TestString.Substring (1);

			if (topChar == 'A') {
				status.NextDirection = ToolOutputDirection.LEFT;
			} else if (topChar == 'B') {
				status.NextDirection = ToolOutputDirection.RIGHT;
			} else {
				throw new ToolExecutionException("Invalid test string. Character was "+topChar);
			}
		}

		public bool CanUseImage ()
		{
			return true;
		}

		#endregion
	}
}
