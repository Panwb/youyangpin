import * as types from '../mutationTypes'

const state = {
    account: null,
    activityTypes: [],
    statistics: []
}

const mutations = {
    [types.SET_ACCOUNT](state, data) {
        state.account = data
    },
    [types.ActivityTypes](state, data) {
        state.activityTypes = data
    },
    [types.setStatistics](state, data) {
        state.statistics = data
    }
}

export default {
    state,
    mutations
}