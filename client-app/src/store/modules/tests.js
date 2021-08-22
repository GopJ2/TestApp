import api from "../../services/api";

const tests = {
    namespaced: true,
    state: () => ({
        tests: []
    }),
    mutations: {
        setTests(state, payload) {
            state.tests = payload;
        },
        changeAgreement({tests}, payload) {
            console.log(payload);
            // eslint-disable-next-line no-debugger
            debugger;
            const index = tests.findIndex(el => el.id === payload.testId);
            if (index > -1) {
                tests[index] = Object.assign(tests[index], {agreementAccepted: payload.checked})
            }
        }
    },
    actions: {
        async loadTests({commit}) {
            try {
                const result = (await api.get('/Test/tests')).data;
                commit('setTests', result);
            }catch (e) {
                return Promise.reject(e);
            }
        },
        // eslint-disable-next-line no-unused-vars
        acceptTestAgreement({commit}, payload) {
            commit('changeAgreement', payload);
        }
    },
    getters: {
        tests: (state) => {
            return state.tests;
        },
        test: (state) => (id) => {
            return state.tests.find(el => el.id === id);
        }
    }
}

export default tests;
