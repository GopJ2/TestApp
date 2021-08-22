import api from '../api';

const loginAsync = async (form) => {
    if (Object.values(form).every(x => x)) {
        const {token, expiresAt} = (await api.post("/Auth/login", form)).data;
        if (token && expiresAt) {
            localStorage.setItem('access_token', token)
            localStorage.setItem('expires', expiresAt);

            return true;
        }

        return false;
    }

    return false;
};

export default loginAsync;