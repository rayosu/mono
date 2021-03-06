//
// ErrorResponseException.cs
//
// Author:
//   Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2009 Novell, Inc.
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.DirectoryServices.Protocols
{
	[Serializable]
	public class ErrorResponseException : DirectoryException, ISerializable
	{
		public ErrorResponseException ()
			: this ("Directory response error")
		{
		}

		public ErrorResponseException (string message)
			: base (message)
		{
		}

		public ErrorResponseException (string message, Exception inner)
			: base (message, inner)
		{
		}

		public ErrorResponseException (DsmlErrorResponse response)
			: this ()
		{
			Response = response;
		}

		public ErrorResponseException (DsmlErrorResponse response, string message)
			: this (response, message, null)
		{
		}

		public ErrorResponseException (DsmlErrorResponse response, string message, Exception inner)
			: base (message, inner)
		{
			Response = response;
		}

		protected ErrorResponseException (SerializationInfo info, StreamingContext context)
		{
			Response = (DsmlErrorResponse) info.GetValue ("Response", typeof (DsmlErrorResponse));
		}

		public DsmlErrorResponse Response { get; private set; }

		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData (SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			serializationInfo.AddValue ("Response", Response, typeof (DsmlErrorResponse));
		}
	}
}
