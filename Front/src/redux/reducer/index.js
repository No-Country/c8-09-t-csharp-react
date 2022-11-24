const initialState = {
    singleUser: [],
    userloginData: []
}

function rootReducer(state = initialState, action) {
    switch(action.type){
        case "CREATE_USER":
            return{
                ...state
            }

        case "LOGIN_USER":
            return{
                ...state,
                userloginData: action.payload
            }

        default: return state;
    }
}

export default rootReducer;