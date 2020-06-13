﻿using System;
using System.Messaging;
using Gallery.MsgQueue.Interfaces;

namespace Gallery.MsgQueue.Services
{
    public class MSMQPublisher : IPublisher
    {
        private readonly MessageQueue _messageQueue;
        private readonly string _messageQueuePath;

        public MSMQPublisher(string messageQueuePath)
        {
            _messageQueuePath = messageQueuePath ?? throw new ArgumentNullException(nameof(messageQueuePath));
            _messageQueue = new MessageQueue(_messageQueuePath);

            if (!MessageQueue.Exists(_messageQueue.Path))
            {
                MessageQueue.Create(_messageQueue.Path);
            }
        }

        public void SendMessage(object message, string label)
        {
            _messageQueue.Send(message, label);
        }
    }
}