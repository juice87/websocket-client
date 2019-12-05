﻿using System;
using System.Net.WebSockets;

// ReSharper disable once CheckNamespace
namespace Websocket.Client
{
    /// <summary>
    /// Info about happened disconnection
    /// </summary>
    public class DisconnectionInfo
    {
        /// <inheritdoc />
        public DisconnectionInfo(DisconnectionType type, WebSocketCloseStatus? closeStatus, 
            string closeStatusDescription, string subProtocol, Exception exception)
        {
            Type = type;
            CloseStatus = closeStatus;
            CloseStatusDescription = closeStatusDescription;
            SubProtocol = subProtocol;
            Exception = exception;
        }

        /// <summary>
        /// Disconnection reason
        /// </summary>
        public DisconnectionType Type { get; }

        /// <summary>
        /// Indicates the reason why the remote endpoint initiated the close handshake 
        /// </summary>
        public WebSocketCloseStatus? CloseStatus { get; }

        /// <summary>
        /// Allows the remote endpoint to describe the reason whe the connection was closed 
        /// </summary>
        public string CloseStatusDescription { get; }

        /// <summary>
        /// The subprotocol that was negotiated during the opening handshake
        /// </summary>
        public string SubProtocol { get; }

        /// <summary>
        /// Exception that cause disconnection, can be null
        /// </summary>
        public Exception Exception { get; }


        /// <summary>
        /// Simple factory method
        /// </summary>
        public static DisconnectionInfo Create(DisconnectionType type, WebSocket client, Exception exception)
        {
            return new DisconnectionInfo(type, client?.CloseStatus, client?.CloseStatusDescription, 
                client?.SubProtocol, exception);
        }
    }
}
