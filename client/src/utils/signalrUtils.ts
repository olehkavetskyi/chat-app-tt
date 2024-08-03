import axios from '../api/axiosConfig';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

interface TokenResponse {
    token: string;
    url: string;
}

export const fetchToken = async (): Promise<TokenResponse> => {
    try {
        const response = await axios.get<TokenResponse>('/signalr/token');
        return response.data;
    } catch (error) {
        console.error('Failed to fetch SignalR token:', error);
        throw new Error('Token fetch failed');
    }
};

export const createSignalRConnection = async (): Promise<HubConnection> => {
    const { token, url } = await fetchToken();
    const connection = new HubConnectionBuilder()
        .withUrl(url, { accessTokenFactory: () => token })
        .withAutomaticReconnect()
        .build();

    return connection;
};
