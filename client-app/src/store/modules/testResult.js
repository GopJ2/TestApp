const testResult = {
    namespaced: true,
    state: () => ({
        result: []
    }),
    mutations: {
        setResult({result}, payload) {
            const index = result.findIndex(el => el.id === payload.id);
            if (index > -1) {
                result[index] = payload;
                return;
            }

            result.push(payload);
        }
    },
    actions: {
        setTestResult({commit}, payload) {
            commit('setResult', payload);
        },
    },
    getters: {
        getTestResultById: (state) => (id) => {
            return state.result.find(el => el.id === id)
        }
    }
}

export default testResult;
