﻿using System;
using VVVV.PluginInterfaces.V1;

namespace VVVV.PluginInterfaces.V2.Input
{
	public class OutputSpreadList<T, TSub> : SpreadList<T, TSub>
	{
		public OutputSpreadList(IPluginHost host, OutputAttribute attribute)
			: base(host, attribute)
		{
		}
		
		//create a pin at position
		protected override T CreatePin(int pos)
		{
			//create pin name
			var origName = FAttribute.Name;
			FAttribute.Name = origName + " " + pos;
			
			var ret	= new OutputWrapperPin<TSub>(FHost, FAttribute as OutputAttribute).Pin;
			
			//set attribute name back
			FAttribute.Name = origName;
			
			return (T)(object)ret;
		}

	}
}