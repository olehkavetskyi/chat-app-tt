import { Link } from 'react-router-dom';
import styles from './HomePage.module.css';

const HomePage = () => {

    return (
        <div className="appContainer">
            <h1>Welcome to the Chat App</h1>
            <Link className={styles.enterLink} to="/chat">Enter Chat</Link>
        </div>
    );
};

export default HomePage;