This is a .Net 9 Blazor Interactive Server Side application.

The reason for this is I have another working application that uses Smartcard authentication. The built in Blazor signalR works without a problem except for when adding SignalR.

Environment:
Windows 11
Visual Studio Enterprise v17.14.16
.Net 9

Details:

This project is to demonstrate failure of SignalR when using Kestrel web server and configuring the server to require client certificates (smartcard).
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.ConfigureHttpsDefaults(options =>
        options.ClientCertificateMode = ClientCertificateMode.RequireCertificate);
    options.AddServerHeader = false;
});

When the requirement for ClientCertificateMode.RequireCertificate is removed, the functionality works as expected.
builder.Services.Configure<KestrelServerOptions>(options =>
{
    //options.ConfigureHttpsDefaults(options =>
    //    options.ClientCertificateMode = ClientCertificateMode.RequireCertificate);
    options.AddServerHeader = false;
});

Failure statement:
await hubConnection.StartAsync();

Exception information:

-		ex	{"An error occurred while sending the request."}	System.Exception {System.Net.Http.HttpRequestException}
		AllowRetry	NoRetry	System.Net.Http.RequestRetryType
+		Data	Count = 0	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}
		HResult	-2146232800	int
		HasBeenThrown	true	bool
		HelpLink	null	string
		HttpRequestError	Unknown	System.Net.Http.HttpRequestError
-		InnerException	{"An HTTP/2 connection could not be established because the server did not complete the HTTP/2 handshake."}	System.Exception {System.IO.IOException}
+		Data	Count = 0	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}
		HResult	-2146232800	int
		HasBeenThrown	true	bool
		HelpLink	null	string
-		InnerException	{"Cannot access a disposed object.\r\nObject name: 'System.Net.Security.SslStream'."}	System.Exception {System.ObjectDisposedException}
+		Data	Count = 0	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}
		HResult	-2146232798	int
		HasBeenThrown	true	bool
		HelpLink	null	string
+		InnerException	null	System.Exception
		Message	"Cannot access a disposed object.\r\nObject name: 'System.Net.Security.SslStream'."	string
		ObjectName	"System.Net.Security.SslStream"	string
		SerializationStackTraceString	"   at System.Net.Security.SslStream.<ThrowIfExceptional>g__ThrowExceptional|131_0(ExceptionDispatchInfo e)\r\n   at System.Net.Security.SslStream.WriteAsync(ReadOnlyMemory`1 buffer, CancellationToken cancellationToken)\r\n   at System.Net.Http.Http2Connection.SetupAsync(CancellationToken cancellationToken)"	string
		SerializationWatsonBuckets	null	object
		Source	"System.Private.CoreLib"	string
		StackTrace	"   at System.ThrowHelper.ThrowObjectDisposedException(Object instance)\r\n   at System.Net.Security.SslStream.<ThrowIfExceptional>g__ThrowExceptional|131_0(ExceptionDispatchInfo e)\r\n   at System.Net.Security.SslStream.WriteAsync(ReadOnlyMemory`1 buffer, CancellationToken cancellationToken)\r\n   at System.Net.Http.Http2Connection.<SetupAsync>d__54.MoveNext()"	string
+		TargetSite	{Void ThrowObjectDisposedException(System.Object)}	System.Reflection.MethodBase {System.Reflection.RuntimeMethodInfo}
		_HResult	-2146232798	int
+		_data	Count = 0	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}
		_exceptionMethod	null	System.Reflection.MethodBase
		_helpURL	null	string
+		_innerException	null	System.Exception
		_ipForWatsonBuckets	0x00007ff84e217653	System.UIntPtr
		_message	"Cannot access a disposed object."	string
		_objectName	"System.Net.Security.SslStream"	string
		_remoteStackTraceString	null	string
		_source	null	string
+		_stackTrace	{sbyte[272]}	object {sbyte[]}
		_stackTraceString	null	string
		_watsonBuckets	null	byte[]
		_xcode	-532462766	int
		_xptrs	0x0000000000000000	System.IntPtr
+		Static members		
		Message	"An HTTP/2 connection could not be established because the server did not complete the HTTP/2 handshake."	string
		SerializationStackTraceString	"   at System.Net.Http.Http2Connection.SetupAsync(CancellationToken cancellationToken)\r\n   at System.Net.Http.HttpConnectionPool.ConstructHttp2ConnectionAsync(Stream stream, HttpRequestMessage request, Activity activity, IPEndPoint remoteEndPoint, CancellationToken cancellationToken)"	string
		SerializationWatsonBuckets	null	object
		Source	"System.Net.Http"	string
		StackTrace	"   at System.Net.Http.Http2Connection.<SetupAsync>d__54.MoveNext()\r\n   at System.Net.Http.HttpConnectionPool.<ConstructHttp2ConnectionAsync>d__102.MoveNext()"	string
+		TargetSite	{Void MoveNext()}	System.Reflection.MethodBase {System.Reflection.RuntimeMethodInfo}
		_HResult	-2146232800	int
+		_data	Count = 0	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}
		_exceptionMethod	null	System.Reflection.MethodBase
		_helpURL	null	string
+		_innerException	{"Cannot access a disposed object.\r\nObject name: 'System.Net.Security.SslStream'."}	System.Exception {System.ObjectDisposedException}
		_ipForWatsonBuckets	0x00007ff84e217653	System.UIntPtr
		_message	"An HTTP/2 connection could not be established because the server did not complete the HTTP/2 handshake."	string
		_remoteStackTraceString	null	string
		_source	null	string
+		_stackTrace	{sbyte[272]}	object {sbyte[]}
		_stackTraceString	null	string
		_watsonBuckets	null	byte[]
		_xcode	-532462766	int
		_xptrs	0x0000000000000000	System.IntPtr
+		Static members		
		Message	"An error occurred while sending the request."	string
		SerializationStackTraceString	"   at System.Net.Http.HttpConnectionPool.ConstructHttp2ConnectionAsync(Stream stream, HttpRequestMessage request, Activity activity, IPEndPoint remoteEndPoint, CancellationToken cancellationToken)\r\n   at System.Net.Http.HttpConnectionPool.InjectNewHttp2ConnectionAsync(QueueItem queueItem)\r\n   at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)\r\n   at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)\r\n   at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)\r\n   at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)\r\n   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean asyn..."	string
		SerializationWatsonBuckets	null	object
		Source	"System.Net.Http"	string
		StackTrace	"   at System.Net.Http.HttpConnectionPool.<ConstructHttp2ConnectionAsync>d__102.MoveNext()\r\n   at System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1.ConfiguredValueTaskAwaiter.GetResult()\r\n   at System.Net.Http.HttpConnectionPool.<InjectNewHttp2ConnectionAsync>d__101.MoveNext()\r\n   at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.<WaitWithCancellationAsync>d__1.MoveNext()\r\n   at System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1.ConfiguredValueTaskAwaiter.GetResult()\r\n   at System.Net.Http.HttpConnectionWaiter`1.<WaitForConnectionWithTelemetryAsync>d__6.MoveNext()\r\n   at System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1.ConfiguredValueTaskAwaiter.GetResult()\r\n   at System.Net.Http.HttpConnectionPool.<SendWithVersionDetectionAndRetryAsync>d__50.MoveNext()\r\n   at System.Net.Http.DiagnosticsHandler.<SendAsyncCore>d__10.MoveNext()\r\n   at System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1.ConfiguredValueTaskAwaiter.GetResult()\r\n   at System.Net.Http.RedirectHandler.<SendAsync>d__4.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.Internal.AccessTokenHttpMessageHandler.<SendAsync>d__3.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.Internal.LoggingHttpMessageHandler.<SendAsync>d__2.MoveNext()\r\n   at System.Net.Http.HttpClient.<<SendAsync>g__Core|83_0>d.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnection.<NegotiateAsync>d__45.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnection.<GetNegotiationResponseAsync>d__52.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnection.<SelectAndStartTransport>d__44.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnection.<StartAsyncCore>d__41.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnection.<StartAsync>d__40.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionFactory.<ConnectAsync>d__3.MoveNext()\r\n   at Microsoft.AspNetCore.Http.Connections.Client.HttpConnectionFactory.<ConnectAsync>d__3.MoveNext()\r\n   at System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1.ConfiguredValueTaskAwaiter.GetResult()\r\n   at Microsoft.AspNetCore.SignalR.Client.HubConnection.<StartAsyncCore>d__62.MoveNext()\r\n   at Microsoft.AspNetCore.SignalR.Client.HubConnection.<StartAsyncInner>d__53.MoveNext()\r\n   at Microsoft.AspNetCore.SignalR.Client.HubConnection.<StartAsync>d__52.MoveNext()\r\n   at BlazorSignalR.Components.Pages.Chat.<OnInitializedAsync>d__6.MoveNext() in D:\\Projects\\BlazorSignalR\\BlazorSignalR\\Components\\Pages\\Chat.razor:line 44"	string
		StatusCode	null	System.Net.HttpStatusCode?
+		TargetSite	{Void MoveNext()}	System.Reflection.MethodBase {System.Reflection.RuntimeMethodInfo}
		_HResult	-2146232800	int
+		_data	Count = 0	System.Collections.IDictionary {System.Collections.ListDictionaryInternal}
		_exceptionMethod	null	System.Reflection.MethodBase
		_helpURL	null	string
+		_innerException	{"An HTTP/2 connection could not be established because the server did not complete the HTTP/2 handshake."}	System.Exception {System.IO.IOException}
		_ipForWatsonBuckets	0x00007ff84e217653	System.UIntPtr
		_message	"An error occurred while sending the request."	string
		_remoteStackTraceString	null	string
		_source	null	string
+		_stackTrace	{sbyte[4112]}	object {sbyte[]}
		_stackTraceString	null	string
		_watsonBuckets	null	byte[]
		_xcode	-532462766	int
		_xptrs	0x0000000000000000	System.IntPtr
+		Static members		

