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
	public class MoveDown : ITool
	{
		public MoveDown ()
		{
		}

		#region ITool implementation

		public void Execute (ref ToolExecutionStatus status)
		{
			status.NextDirection = ToolOutputDirection.DOWN;
			status.Status = ToolStatus.NO_STATUS;
		}

		public bool CanUseImage()
		{
			return true;
		}

		#endregion
	}
}

