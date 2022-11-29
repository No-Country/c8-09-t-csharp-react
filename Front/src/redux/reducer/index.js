import jwt_decode from "jwt-decode";

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
    userloginData: [],
    isLogged: null
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
            const initialData = action.payload
            const decode = jwt_decode(initialData.token)
            localStorage.setItem("user", JSON.stringify(decode))
            return{
                ...state,
                userloginData: decode
            }
        case "CHECK_LOCAL_STORAGE":
            return {
                ...state,
                isLogged: action.payload
            }

        default: return state;
    }
}

export default rootReducer;