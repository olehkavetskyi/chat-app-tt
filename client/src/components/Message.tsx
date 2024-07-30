import React from 'react';
import styles from './Message.module.css';

interface MessageProps {
    content: string;
    sentiment: string;
}

const Message: React.FC<MessageProps> = ({ content, sentiment }) => {


    const sentimentClass = sentiment === 'positive'
        ? styles.messagePositive
        : sentiment === 'negative'
        ? styles.messageNegative
        : styles.messageNeutral;

    return (
        <div className={`${styles.message} ${sentimentClass}`}>
            <div className={styles.messageContent}>{content}</div>
            <div className={styles.messageAuthor}>Anonymous</div>
        </div>
    );
};

export default Message;
