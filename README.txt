INSTRUCTIONS

1.- Change the Websocket URL according to your enviroment in the following paths.
	a) WebSocketSample\WebSocketClient\Program.cs
	b) WebSocketSample\WebSocketApplication\Pages\Index.cshtml
2.- Run first the WebSocketApplication project and the index page should show: 
	a) Status: Socket is opened.
3.- Run the WebSocketClient project and the console should show:
	a) The same message it was sent "Test Message".
	b) Enter any key in the console to continue with the execution.
	c) The following ERROR is shown in the console:
	Fatal|<>c__DisplayClass174_0.<startReceiving>b__2:2186|WebSocketSharp.WebSocketException: The header of a frame cannot be read from the stream.
                               at WebSocketSharp.WebSocketFrame.processHeader(Byte[] header) in C:\_projects\GitHub\WebSocketSample\websocket-sharp\WebSocketFrame.cs:line 438
                               at WebSocketSharp.WebSocketFrame.<>c__DisplayClass73_0.<readHeaderAsync>b__0(Byte[] bytes) in C:\_projects\GitHub\WebSocketSample\websocket-sharp\WebSocketFrame.cs:line 535
                               at WebSocketSharp.Ext.<>c__DisplayClass58_0.<ReadBytesAsync>b__0(IAsyncResult ar) in C:\_projects\GitHub\WebSocketSample\websocket-sharp\Ext.cs:line 808