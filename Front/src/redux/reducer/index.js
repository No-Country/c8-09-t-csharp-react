const singleUserEmpty = {
    id: 0,
    name: "",
    email: "",
    rol: "",
}

const initialState = {
    singleUser: [],
    allEvents: [],
    singleUser: localStorage.getItem('user') ? JSON.parse(localStorage.getItem('user')) : singleUserEmpty,
    userloginData: []
}

function rootReducer(state = initialState, action) {
    switch (action.type) {
        case "CREATE_USER":
            return {
                ...state
            }
        case "GET_EVENTS":
            return{
                ...state,
                allEvents: action.payload
                }
        case "CLEAR_USER":
            return {
                ...state,
                singleUser: singleUserEmpty
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