const initialState = {
    singleUser: []
}

function rootReducer(state = initialState, action) {
    switch(action.type){
        case "CREATE_USER":
            return{
                ...state
            }

        default: return state;
    }
}

export default rootReducer;