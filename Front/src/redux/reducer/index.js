const initialState = {
    singleUser: [],
    allEvents: []
}

function rootReducer(state = initialState, action) {
    switch(action.type){
        case "CREATE_USER":
            return{
                ...state
            }
        case "GET_EVENTS":
            return{
                ...state,
                allEvents: action.payload
            }
        default: return state;
    }
}

export default rootReducer;