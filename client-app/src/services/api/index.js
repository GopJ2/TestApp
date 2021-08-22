import axios from 'axios';

const axiosConfig = {
    baseURL: 'https://localhost:44381/api',
    timeout: 30000,
};

let api = axios.create(axiosConfig);

api.interceptors.request.use(function (config) {
    config.headers.Authorization = localStorage.getItem('access_token') ?? null;
    return config;
});

api.interceptors.response.use(response => {
    if (response.status === 200) {
        return response;
    }
    return Promise.reject(response);
}, error => {
    if (error) {
        if (error.response && error.response.status === 401) {
            localStorage.removeItem('access_token');
            if (!window.location.href.indexOf("login") > -1) {
                window.location.href = '/login';
            }
            return;
        }
    }

    return Promise.reject(error);
});

export default api;