import * as types from '../mutationTypes';

export default {
    setAccount: ({ commit }, data) => {
        commit(types.SET_ACCOUNT, data);
    },
    setActivityTypes: ({ commit }, data) => {
        commit(types.ActivityTypes, data);
    },
    setStatistics: ({ commit }, data) => {
        commit(types.setStatistics, data);
    },
};
