import { useNavigate } from 'react-router-dom';

const Home = () => {
    const navigate = useNavigate();

    const navigateToChat = () => {
        navigate('/chat');
    };

    return (
        <div className="appContainer">
            <h1>Welcome to the Chat App</h1>
            <button onClick={navigateToChat}>Enter Chat</button>
        </div>
    );
};

export default Home;