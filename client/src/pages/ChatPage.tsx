import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@microsoft/signalr';
import Message from '../components/Message';
import styles from './ChatPage.module.css';
import { v4 as uuidv4 } from 'uuid';
import { useNavigate } from 'react-router-dom';

interface MessageData {
    id: string;
    content: string;
    sentiment: string;
    timestamp: string;
}

const ChatPage: React.FC = () => {
    const [connection, setConnection] = useState<HubConnection | null>(null);
    const [messages, setMessages] = useState<MessageData[]>([]);
    const [message, setMessage] = useState<string>('');
    const messagesEndRef = useRef<HTMLDivElement | null>(null);


    const navigate = useNavigate();

    useEffect(() => {
        const fetchMessages = async () => {
            try {
                const response = await axios.get<MessageData[]>('https://chatappbd.azurewebsites.net/api/chat');
                setMessages(response.data);
            } catch (error) {
                console.error('Error fetching messages', error);
            }
        };

        fetchMessages();

        const newConnection = new HubConnectionBuilder()
            .withUrl('https://chatappbd.azurewebsites.net/chatHub', {
            })
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    connection.on('ReceiveMessage', (content: string, sentiment: string) => {
                        setMessages(prevMessages => [
                            ...prevMessages,
                            { id: uuidv4() , content, sentiment, timestamp: new Date().toISOString() },
                        ]);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    useEffect(() => {
        if (messagesEndRef.current) {
            messagesEndRef.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [messages]);


    const sendMessage = async () => {
        if (connection && connection.state === HubConnectionState.Connected) {
            try {
                await connection.send('SendMessage', message);
                setMessage('');
            } catch (e) {
                console.log(e);
            }
        } else {
            alert('No connection to server yet.');
        }
    };

    const leaveChat = () => {
        if (connection) {
            connection.stop().then(() => navigate('/'));
        } else {
            navigate('/');
        }
    };

    return (
        <div className={styles.chatContainer}>
            <div className={styles.chatHeader}>
                <h1 className={styles.chatTitle}>Anonymous Chat</h1>
                <button className={styles.leaveButton} onClick={leaveChat}>Leave</button>
            </div>
            <div className={styles.messageList}>
                {messages.map((msg) => (
                    <Message
                        key={msg.id}
                        content={msg.content}
                        sentiment={msg.sentiment}
                    />
                ))}
                <div ref={messagesEndRef} />
            </div>
            <div className={styles.inputContainer}>
                <input
                    type="text"
                    className={styles.inputField}
                    value={message}
                    onChange={(e) => setMessage(e.target.value)}
                />
                <button className={styles.sendButton} onClick={sendMessage}>Send</button>
            </div>
        </div>
    );
};

export default ChatPage;